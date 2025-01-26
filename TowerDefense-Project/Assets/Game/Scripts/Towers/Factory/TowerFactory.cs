using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public interface ITowerFactory
    {
        void CreateTower(TowerConfig.TowerType type, Vector3 position);
    }

    public class TowerFactory : ITowerFactory
    {
        private readonly IObjectResolver container;
        private readonly Dictionary<TowerConfig.TowerType, TowerConfig> configs;
        private readonly GameObject towerPrefab;

        public TowerFactory(IObjectResolver container, GameObject towerPrefab, TowerConfig[] towerConfigs)
        {
            this.container = container;
            this.towerPrefab = towerPrefab;
            
            configs = new Dictionary<TowerConfig.TowerType, TowerConfig>();
            foreach (var config in towerConfigs)
            {
                configs[config.Type] = config;
            }
        }

        public void CreateTower(TowerConfig.TowerType type, Vector3 position)
        {
            if (!configs.TryGetValue(type, out var config))
            {
                Debug.LogError($"Config not found for type: {type}");
                return;
            }

            var towerObj = container.Instantiate(config.TowerPrefab, position, Quaternion.identity);
            var tower = towerObj.GetComponent<BasicTower>();
            tower.ApplyConfig(config);
        }
    }
}