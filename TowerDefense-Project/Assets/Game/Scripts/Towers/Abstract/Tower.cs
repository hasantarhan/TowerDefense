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
            bullet.Initialize(config.Damage, config.BulletSpeed);
            var direction = enemy.Position - transform.position;
            bullet.Shoot(direction.normalized);
        }
        
        public void OverlapCheckEnemy()
        {
            var colliders = Physics.OverlapSphere(transform.position, config.Range);
            IEnemy closestEnemy = null;
            float closestDistance = Mathf.Infinity;

            foreach (var collider in colliders)
            {
                IEnemy enemy = collider.GetComponent<IEnemy>();
                if (enemy != null && enemy.IsAlive)
                {
                    float distance = Vector3.Distance(transform.position, collider.transform.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestEnemy = enemy;
                    }
                }
            }

            if (closestEnemy != null)
            {
                Attack(closestEnemy);
            }
        }
        public void ApplyConfig(TowerConfig towerConfig)
        {
            config = towerConfig;
        }

    }
}