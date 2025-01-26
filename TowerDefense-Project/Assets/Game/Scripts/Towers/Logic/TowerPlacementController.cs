using System;
using System.Collections.Generic;
using Game;
using Game.Domain;
using Game.Scripts.Common;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

public class TowerPlacementController : MonoBehaviour
{
    private ITowerFactory towerFactory;
    private TowerConfig.TowerType selectedType = TowerConfig.TowerType.Basic;
    private GameConfig gameConfig;
    private bool canPlacement = false;
    private bool IsMaxTowerCount => gameConfig.runtimeGameData.TowerCount < gameConfig.maxTowerCount;
    [Inject]
    public void Construct(ITowerFactory towerFactory, GameConfig gameConfig)
    {
        this.towerFactory = towerFactory;
        this.gameConfig = gameConfig;
    }

    private void Update()
    {
        if (!canPlacement || !IsMaxTowerCount)
        {
            return;
        }
        HandleTowerSelection();
        HandlePlacement();
    }

    private void HandleTowerSelection()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) selectedType = TowerConfig.TowerType.Basic;
        if (Input.GetKeyDown(KeyCode.Alpha2)) selectedType = TowerConfig.TowerType.Slow;
        if (Input.GetKeyDown(KeyCode.Alpha3)) selectedType = TowerConfig.TowerType.Fast;
    }

    private void HandlePlacement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TryGetValidSpawnPosition(out Vector3 spawnPos))
            {
                towerFactory.CreateTower(selectedType, spawnPos);
                gameConfig.runtimeGameData.TowerCount++;
            }
        }
    }
    private bool TryGetValidSpawnPosition(out Vector3 position)
    {
        position = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, LayerMask.GetMask("Ground")))
        {
   
            Collider[] pathColliders = Physics.OverlapBox(
                hit.point, 
                Vector3.one * 0.5f,
                Quaternion.identity, 
                LayerMask.GetMask("Path")
            );
            
            if (pathColliders.Length == 0)
            {
                position = hit.point;
                return true;
            }
        }
        return false;
    }

    public void EnablePlacement()
    {
        canPlacement = true;
    }
    public void DisablePlacement()
    {
        canPlacement = false;
    }
}