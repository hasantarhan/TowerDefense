using Game.Domain;
using Game.Scripts.Common;
using Game.Scripts.Enemies.Data;
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
        
        [Header("Configurations")]
        [SerializeField] private TowerConfig[] towerConfigs;
        [SerializeField] private WaveConfig[] waveConfigs;
        [SerializeField] private GameConfig gameConfig;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(enemySpawner)
                .As<ISpawner>()
                .AsSelf()
                .WithParameter(waveConfigs)
                .WithParameter(gameConfig); 
            
            builder.Register<EnemyFactory>(Lifetime.Singleton)
                .WithParameter(enemyPrefab)
                .As<IEnemyFactory>();

            builder.RegisterComponent(towerPlacementController)
                .WithParameter(gameConfig)
                .AsSelf();
            
            builder.Register<BuildingState>(Lifetime.Singleton);
            builder.Register<CombatState>(Lifetime.Singleton);
            builder.Register<GameStateMachine>(Lifetime.Singleton).AsSelf();
            
            builder.RegisterComponent(uiController)
                .WithParameter(gameConfig)
                .AsSelf();
            builder.RegisterComponent(path).AsSelf();
            
            builder.Register<TowerFactory>(Lifetime.Singleton)
                .WithParameter(towerConfigs) 
                .As<ITowerFactory>();
            
            gameConfig.ResetRuntimeData();
        }
    }
}