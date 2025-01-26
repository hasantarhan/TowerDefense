using System;
using Game.Domain;
using UnityEngine;
using VContainer;
namespace Game
{
    public class EnemySpawner : MonoBehaviour,ISpawner
    {
        [SerializeField] 
        private float spawnInterval = 2f;
        private IEnemyFactory enemyFactory;
        private float timer;
        private bool spawningActive;
        
        [Inject]
        public void Construct(IEnemyFactory enemyFactory)
        {
            this.enemyFactory = enemyFactory;
        }
        public void StartSpawning()
        {
            spawningActive = true;
            timer = 0f;
        }
        public void StopSpawning()
        {
            spawningActive = false;
        }
        private void SpawnEnemy()
        {
            enemyFactory.CreateEnemy(Vector3.zero);
        }
        private void Update()
        {
            if (!spawningActive) return;

            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                timer = 0f;
                SpawnEnemy();
            }
        }
    }
}