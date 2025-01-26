using System.Collections.Generic;
using UnityEngine;
namespace Hasan.Misc
{
    
    public static class Bomb
    {
        public static void Explode(Vector3 position, float radius, float explosionForce, float upwardsModifier)
        {
            var collider = Physics.OverlapSphere(position, radius);
            for (int i = 0; i < collider.Length; i++)
                if (collider[i].TryGetComponent(out Rigidbody rb))
                    rb.AddExplosionForce(explosionForce, position, radius, upwardsModifier, ForceMode.Impulse);
        }

        public static void Explode(Vector3 position, float radius, float explosionForce, float upwardsModifier,
            LayerMask layerMask, int maxCount = 100)
        {
            var colliders = new Collider[maxCount];
            int colliderCount = Physics.OverlapSphereNonAlloc(position, radius, colliders, layerMask);

            for (int i = 0; i < colliderCount; i++)
                if (colliders[i].TryGetComponent(out Rigidbody rb))
                    rb.AddExplosionForce(explosionForce, position, radius, upwardsModifier, ForceMode.Impulse);
        }

        public static void Explode(Vector3 position, float radius, float explosionForce, float upwardsModifier,
            out Rigidbody[] bodies)
        {
            var colliders = Physics.OverlapSphere(position, radius);
            var rigidbodies = new List<Rigidbody>();
            for (int i = 0; i < colliders.Length; i++)
                if (colliders[i].TryGetComponent(out Rigidbody rb))
                {
                    rb.AddExplosionForce(explosionForce, position, radius, upwardsModifier, ForceMode.Impulse);
                    rigidbodies.Add(rb);
                }

            bodies = rigidbodies.ToArray();
        }

        public static void Explode(Vector3 position, float radius, float explosionForce, float upwardsModifier,
            LayerMask layerMask, out Rigidbody[] bodies, int maxCount = 100)
        {
            var colliders = new Collider[maxCount];
            int colliderCount = Physics.OverlapSphereNonAlloc(position, radius, colliders, layerMask);
            var rigidbodies = new Rigidbody[colliderCount];

            for (int i = 0; i < colliderCount; i++)
                if (colliders[i].TryGetComponent(out Rigidbody rb))
                {
                    rb.AddExplosionForce(explosionForce, position, radius, upwardsModifier, ForceMode.Impulse);
                    rigidbodies[i] = rb;
                }

            bodies = rigidbodies;
        }
    }
}
