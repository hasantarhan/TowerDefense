using System;
using System.Collections.Generic;
using Game.Domain;
using UnityEngine;
using VContainer;
using VContainer.Unity;
namespace Game
{
    public class GameLifetime : LifetimeScope
    {
        [SerializeField] private Spawner spawner;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private TowerPlacementController towerPlacementController;

        [Header("Tower Prefabs")]
        [SerializeField] private GameObject basicTowerPrefab;
        [SerializeField] private GameObject slowTowerPrefab;
        [SerializeField] private GameObject fastTowerPrefab;
        
        public TowerConfig[] towerConfigs;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(spawner)
                .As<ISpawner>()
                .AsSelf();
            builder.Register<EnemyFactory>(Lifetime.Singleton)
                .WithParameter(enemyPrefab)   
                .As<IEnemyFactory>();

            builder.RegisterComponent(towerPlacementController)
                .AsSelf();

         
            var towerPrefabs = new Dictionary<Type, GameObject>
            {
                { typeof(BasicTower), basicTowerPrefab },
                { typeof(SlowTower), slowTowerPrefab },
                { typeof(FastTower), fastTowerPrefab }
            };

         
            builder.Register<TowerFactory>(Lifetime.Singleton)
                .WithParameter(towerPrefabs)
                .As<ITowerFactory>();
        }
    }
}