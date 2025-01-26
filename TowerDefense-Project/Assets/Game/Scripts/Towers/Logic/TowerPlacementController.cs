using System;
using System.Collections.Generic;
using Game;
using Game.Domain;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;
using ITowerFactory = Game.ITowerFactory;

public class TowerPlacementController : MonoBehaviour
{
    private ITowerFactory towerFactory;
    private TowerConfig.TowerType selectedType = TowerConfig.TowerType.Basic;

    private bool canPlacement = false;
    [Inject]
    public void Construct(ITowerFactory towerFactory)
    {
        this.towerFactory = towerFactory;
    }

    private void Update()
    {
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
            Vector3 spawnPos = GetSpawnPosition();
            towerFactory.CreateTower(selectedType, spawnPos);
        }
    }
    private Vector3 GetSpawnPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            return hit.point;
        }
        return Vector3.zero;
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


