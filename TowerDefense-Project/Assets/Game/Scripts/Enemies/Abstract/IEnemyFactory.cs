using UnityEngine;
namespace Game.Domain
{
    public interface IEnemyFactory
    {
        IEnemy CreateEnemy(Vector3 spawnPosition);
        void ReleaseEnemy(IEnemy enemy);
    }
}