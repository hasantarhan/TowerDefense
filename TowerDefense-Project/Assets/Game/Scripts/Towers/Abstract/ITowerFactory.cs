using UnityEngine;
namespace Game.Domain
{
    public interface ITowerFactory
    {
        void CreateTower(TowerConfig.TowerType type, Vector3 position);
    }
}