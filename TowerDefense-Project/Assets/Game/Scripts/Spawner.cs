using System;
using Game.Domain;
using UnityEngine;
namespace Game
{
    public class Spawner : MonoBehaviour,ISpawner
    {
        [SerializeField] 
        private float spawnInterval = 2f;
        private IEnemyFactory enemyFactory;
        private float timer;
        private bool spawningActive;
        
        [VContainer.Inject]
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
        private void Start()
        {
            StartSpawning();
        }
    }
}