using System;
using System.Collections.Generic;
using Game;
using Game.Domain;
using UnityEngine;
using VContainer;

public class TowerPlacementController : MonoBehaviour
{
    private ITowerFactory towerFactory;
    private Dictionary<KeyCode, Action<Vector3>> towerSpawnActions;
    private Action<Vector3> selectedSpawnAction;
    private Camera camera;
    [Inject]
    public void Construct(ITowerFactory towerFactory)
    {
        this.towerFactory = towerFactory;
    }

    private void Awake()
    {
        camera = Camera.main;
        towerSpawnActions = new Dictionary<KeyCode, Action<Vector3>>
        {
            { KeyCode.Alpha1, pos => towerFactory.CreateTower<BasicTower>(pos) },
            { KeyCode.Alpha2, pos => towerFactory.CreateTower<SlowTower>(pos) },
            { KeyCode.Alpha3, pos => towerFactory.CreateTower<FastTower>(pos) }
        };
        
        selectedSpawnAction = towerSpawnActions[KeyCode.Alpha1];
    }

    private void Update()
    {
        foreach (var kvp in towerSpawnActions)
        {
            if (Input.GetKeyDown(kvp.Key))
            {
                selectedSpawnAction = kvp.Value;
                Debug.Log($"Selected tower: {kvp.Key}");
            }
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 spawnPos = GetSpawnPosition();
            selectedSpawnAction?.Invoke(spawnPos);
        }
    }

    private Vector3 GetSpawnPosition()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}
