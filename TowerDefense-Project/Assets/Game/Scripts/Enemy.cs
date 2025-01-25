using Game.Domain;
using UnityEngine;
using VContainer;

namespace Game
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        public float Health { get; set; }
        public bool IsAlive => Health > 0;
        private IEnemyFactory enemyFactory;

        [Inject]
        public void Construct(IEnemyFactory poolingFactory)
        {
            enemyFactory = poolingFactory;
        }

        public void Initialize()
        {
            Health = 10f;
        }

        public void TakeDamage(float amount)
        {
            Health -= amount;
            if (Health <= 0)
            {
                Die();
            }
        }
        
        private void Die()
        {
            enemyFactory.ReleaseEnemy(this);
        }
    }
}