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
    
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(spawner)
                .As<ISpawner>()
                .AsSelf();
            builder.Register<EnemyFactory>(Lifetime.Singleton)
                .WithParameter(enemyPrefab)   
                .As<IEnemyFactory>();         
            
      
        }
    }
}