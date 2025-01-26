using Game.Domain;
using UnityEngine;
using VContainer;
namespace Game
{
    public abstract class Tower : MonoBehaviour,ITower
    {
        private TowerConfig config;
        private float fireTimer;
        public float Range => config.Range;
        public float Damage => config.Damage;
        
        private void Update()
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= config.FireRate)
            {
                OverlapCheckEnemy();
                fireTimer = 0f;
            }
        }

        public void Attack(IEnemy enemy)
        {
            var bullet = Instantiate(config.BulletPrefab, transform.position, Quaternion.identity);
            bullet.Initialize(config.Damage, config.BulletSpeed, config.SlowPercentage);
            var direction = enemy.Position - transform.position;
            bullet.Shoot(direction.normalized);
        }
        
        public void OverlapCheckEnemy()
        {
            var colliders = Physics.OverlapSphere(transform.position, config.Range);
            foreach (var collider in colliders)
            {
                var enemy = collider.GetComponent<IEnemy>();
                if (enemy != null)
                {
                    Attack(enemy);
                }
            }
        }
        public void ApplyConfig(TowerConfig towerConfig)
        {
            config = towerConfig;
        }

    }
}