using Game.Domain;
using UnityEngine;
using UnityEngine.Pool;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IObjectResolver container;
        private readonly ObjectPool<GameObject> enemyPool;
        
        public EnemyFactory(IObjectResolver container, GameObject enemyPrefab)
        {
            this.container = container;
            enemyPool = new ObjectPool<GameObject>(
                createFunc: () => this.container.Instantiate(enemyPrefab),
                actionOnGet:   enemyGo => 
                {
                    enemyGo.SetActive(true);
                },
                actionOnRelease: enemyGo => 
                {
                    enemyGo.SetActive(false);
                },
                actionOnDestroy: enemyGo =>
                {
                    if (enemyGo != null)
                        Object.Destroy(enemyGo);
                },
                collectionCheck: false,
                defaultCapacity: 10,
                maxSize: 50
            );
        }

        public IEnemy CreateEnemy(Vector3 spawnPosition)
        {
            GameObject enemyObject = enemyPool.Get();
            enemyObject.transform.position = spawnPosition;
            if (enemyObject.TryGetComponent<IEnemy>(out var enemy))
            {
                enemy.Initialize();
                return enemy;
            }
            
            Debug.LogError("Spawned Enemy doesn't implement IEnemy!");
            return null;
        }
        
        public void ReleaseEnemy(IEnemy enemy)
        {
            if (enemy is MonoBehaviour enemyMB)
            {
                enemyPool.Release(enemyMB.gameObject);
            }
        }
    }
}
