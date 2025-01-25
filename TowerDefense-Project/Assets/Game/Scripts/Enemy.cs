using Game.Domain;
using UnityEngine;
namespace Game
{
    public class Enemy : MonoBehaviour,IEnemy
    {
        [SerializeField] private float health = 10f;
        public float Health => health;
        public bool IsAlive => health > 0;

        public void Initialize()
        {
            health = 10f;
            Debug.Log("Hello");
        }

        public void TakeDamage(float amount)
        {
            health -= amount;
            if (!IsAlive)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}