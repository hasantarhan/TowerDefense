using System;
using UnityEngine;
namespace Game.Domain
{
    public interface IEnemy
    {
        void TakeDamage(float amount);
        float Health { get; }
        bool IsAlive { get; }
        Vector3 Position { get;}
        Action OnDie { get; set; }
    }
}