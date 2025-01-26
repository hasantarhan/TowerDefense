using System.Collections.Generic;
using Game.Domain;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game
{


    public class TowerFactory : ITowerFactory
    {
        private readonly IObjectResolver container;
        private readonly Dictionary<TowerConfig.TowerType, TowerConfig> configs;

        public TowerFactory(IObjectResolver container, TowerConfig[] towerConfigs)
        {
            this.container = container;
            
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