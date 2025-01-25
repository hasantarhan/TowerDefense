using System;
using System.Collections.Generic;
using Game.Domain;
using UnityEngine;
using VContainer;
using VContainer.Unity;
namespace Game
{
    public class TowerFactory : MonoBehaviour,ITowerFactory
    {
        private readonly IObjectResolver resolver;
        private readonly Dictionary<Type, GameObject> towerPrefabs;

        public TowerFactory(IObjectResolver resolver, Dictionary<Type, GameObject> towerPrefabs)
        {
            this.resolver = resolver;
            this.towerPrefabs = towerPrefabs;
        }

        public T CreateTower<T>(Vector3 position) where T : MonoBehaviour, ITower
        {
            var towerType = typeof(T);
            
            if (!towerPrefabs.TryGetValue(towerType, out var prefab))
            {
                Debug.LogError($"No prefab registered for tower type {towerType.Name}!");
                return null;
            }
            
            var towerObject = resolver.Instantiate(prefab, position, Quaternion.identity);
            
            var towerComponent = towerObject.GetComponent<T>();
            if (towerComponent == null)
            {
                Debug.LogError($"Spawned prefab does not have a component of type {towerType.Name}!");
                return null;
            }
            return towerComponent;
        }
        
    }
}