using Game.Domain;
using UnityEngine;
namespace Game
{
    public class Tower : MonoBehaviour,ITower
    {
        [SerializeField] private float range = 5f;
        [SerializeField] private float damage = 2f;

        public float Range => range;
        public float Damage => damage;

        private Collider[] results = new Collider[100];
        public void Attack(IEnemy enemy)
        {
            if (enemy == null || !enemy.IsAlive) return;
            
            enemy.TakeDamage(damage);
        }

        private void Update()
        {
            OverlapCheck();
        }
        private void OverlapCheck()
        {
            Physics.OverlapSphereNonAlloc(transform.position, range, results);
            foreach (var hit in results)
            {
                if (hit.TryGetComponent<IEnemy>(out var enemy))
                {
                    Attack(enemy);
                    break;
                }
            }
        }
    }
}