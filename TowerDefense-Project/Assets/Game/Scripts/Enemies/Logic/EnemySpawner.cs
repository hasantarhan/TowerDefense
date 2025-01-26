using System;
using Game.Domain;
using Game.Scripts.Enemies.Data;
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
        private Path path;
        private WaveConfig[] waveConfigs;
        
        [Inject]
        public void Construct(IEnemyFactory enemyFactory, Path path, WaveConfig[] waveConfigs)
        {
            this.enemyFactory = enemyFactory;
            this.path = path;
            this.waveConfigs = waveConfigs;
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
            enemyFactory.CreateEnemy(path.GetPoint(0));
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