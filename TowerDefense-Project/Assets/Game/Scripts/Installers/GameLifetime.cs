using Game.Domain;
using UnityEngine;
using VContainer;
using VContainer.Unity;
namespace Game
{
    public class GameLifetime : LifetimeScope
    {
        [Header("Game References")]
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private Path path;
        [SerializeField] private TowerPlacementController towerPlacementController;
        [SerializeField] private UIController uiController;
        
        [Header("Prefab References")]
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private GameObject basicTowerPrefab;
        
        public TowerConfig[] towerConfigs;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(enemySpawner)
                .As<ISpawner>()
                .AsSelf();
            builder.Register<EnemyFactory>(Lifetime.Singleton)
                .WithParameter(enemyPrefab)   
                .As<IEnemyFactory>();

            builder.RegisterComponent(towerPlacementController)
                .AsSelf();
            
            builder.Register<BuildingState>(Lifetime.Singleton);
            builder.Register<CombatState>(Lifetime.Singleton);
            builder.Register<GameStateMachine>(Lifetime.Singleton).AsSelf();
            
            builder.RegisterComponent(uiController).AsSelf();
            builder.RegisterComponent(path).AsSelf();
            
            builder.Register<TowerFactory>(Lifetime.Singleton)
                .WithParameter(basicTowerPrefab) 
                .WithParameter(towerConfigs) 
                .As<ITowerFactory>();
        }
    }
}