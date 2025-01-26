using Game.Domain;
using UnityEngine;
using VContainer;

namespace Game
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        public float Health { get; set; }
        public bool IsAlive => Health > 0;
        public Vector3 Position => transform.position;
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
            if (!IsAlive)
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