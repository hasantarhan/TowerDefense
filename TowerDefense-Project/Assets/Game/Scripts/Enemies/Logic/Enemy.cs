using System;
using Game.Domain;
using UnityEngine;
using VContainer;

namespace Game
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        private float maxHealth;
        public float health = 10;
        public float Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }
        public bool IsAlive => Health > 0;
        public Vector3 Position => transform.position;
        public Action OnDie { get; set; }
        private IEnemyFactory enemyFactory;

        [Inject]
        public void Construct(IEnemyFactory poolingFactory)
        {
            enemyFactory = poolingFactory;
            maxHealth = health;
        }
        private void OnEnable()
        {
            health = maxHealth;
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
            OnDie?.Invoke();
        }
    }
}