using Game.Domain;
using UnityEngine;
using VContainer;
using VContainer.Unity;
namespace Game
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IObjectResolver container;
        private readonly GameObject enemyPrefab;

        public EnemyFactory(IObjectResolver container, GameObject enemyPrefab)
        {
            this.container = container;
            this.enemyPrefab = enemyPrefab;
        }

        public IEnemy CreateEnemy(Vector3 spawnPosition)
        {
            GameObject enemyObject = container.Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            if (enemyObject.TryGetComponent<IEnemy>(out IEnemy enemy))
            {
                enemy.Initialize();
                return enemy;
            }
            return null;
        }
    }
}