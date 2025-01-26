using System;
using Game.Domain;
using Game.Scripts.Common;
using Game.Scripts.Enemies.Data;
using UnityEngine;
using VContainer;
namespace Game
{
    public class EnemySpawner : MonoBehaviour, ISpawner
    {
        [SerializeField]
        private float spawnInterval = 2f;
        private float timer;
        private bool spawningActive;
        private int currentWaveIndex;
        private int currentSpawnedEnemyCount;
        private IEnemyFactory enemyFactory;
        private Path path;
        private WaveConfig[] waveConfigs;
        private GameConfig gameConfig;
        private WaveConfig CurrentWaveConfig => waveConfigs[currentWaveIndex];

        [Inject]
        public void Construct(IEnemyFactory enemyFactory, Path path, WaveConfig[] waveConfigs, GameConfig gameConfig)
        {
            this.enemyFactory = enemyFactory;
            this.path = path;
            this.waveConfigs = waveConfigs;
            this.gameConfig = gameConfig;
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
            var spawnedEnemy = enemyFactory.CreateEnemy(path.GetPoint(0));
            spawnedEnemy.OnDie = () => gameConfig.runtimeGameData.DiedEnemyCount++;
            gameConfig.runtimeGameData.WaveEnemyCount = CurrentWaveConfig.enemyCount;
            currentSpawnedEnemyCount++;
            if (CurrentWaveConfig.enemyCount<=currentSpawnedEnemyCount)
            {
                currentSpawnedEnemyCount = 0;
                currentWaveIndex++;
                if (currentWaveIndex >= waveConfigs.Length)
                {
                    enabled = false;
                }
            }
        }
        private void Update()
        {
            if (!spawningActive) return;

            timer += Time.deltaTime;
            if (timer >= CurrentWaveConfig.spawnInterval)
            {
                timer = 0f;
                SpawnEnemy();
            }
        }
    }
}