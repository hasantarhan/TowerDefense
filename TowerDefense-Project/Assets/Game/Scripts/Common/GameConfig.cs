using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;
namespace Game.Scripts.Common
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Game/Game Config", order = 0)]
    public class GameConfig : ScriptableObject
    {
        public int maxTowerCount;
        public RuntimeGameData runtimeGameData;

        public void ResetRuntimeData()
        {
            runtimeGameData.TowerCount = 0;
            runtimeGameData.DiedEnemyCount = 0;
        }
    }

    [Serializable]
    public class RuntimeGameData
    {
        [SerializeField, ReadOnly] private int towerCount;
        [SerializeField, ReadOnly] private int waveEnemyCount;
        [SerializeField, ReadOnly] private int diedEnemyCount;
        public int TowerCount
        {
            get
            {
                return towerCount;
            }
            set
            {
                towerCount = value;
                OnTowerCountChanged?.Invoke(value);
            }
        }
        public int DiedEnemyCount
        {
            get
            {
                return diedEnemyCount;
            }
            set
            {
                diedEnemyCount = value;
                OnDiedEnemyCountChanged?.Invoke(value);
            }
        }
        public int WaveEnemyCount
        {
            get
            {
                return waveEnemyCount;
            }
            set
            {
                waveEnemyCount = value;
            }
        }
        public Action<int> OnTowerCountChanged;
        public Action<int> OnDiedEnemyCountChanged;
    }
}