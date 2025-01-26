using Game.Domain;
using UnityEngine;
using VContainer;
namespace Game
{
    public abstract class Tower : MonoBehaviour,ITower
    {
        private TowerConfig config;
        private float fireTimer;
        private Collider[] overlapResults = new Collider[50];
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
            int hitCount = Physics.OverlapSphereNonAlloc(transform.position, config.Range, overlapResults);
            IEnemy closestEnemy = null;
            float closestDistance = Mathf.Infinity;

            for (int i = 0; i < hitCount; i++)
            {
                IEnemy enemy = overlapResults[i].GetComponent<IEnemy>();
                if (enemy != null && enemy.IsAlive)
                {
                    float distance = Vector3.Distance(transform.position, overlapResults[i].transform.position);
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