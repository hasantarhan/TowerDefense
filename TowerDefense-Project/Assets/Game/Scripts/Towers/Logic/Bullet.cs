using System;
using UnityEngine;
namespace Game
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [HideInInspector] public float damage;
        [HideInInspector] public float speed;
        private Rigidbody rb;
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        public void Initialize(float damage, float speed)
        {
            this.damage = damage;
            this.speed = speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Enemy>(out var enemy))
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
        public void Shoot(Vector3 direction)
        {
            transform.forward = direction;
            rb.AddForce(direction* speed, ForceMode.Impulse);
        }
    }
}