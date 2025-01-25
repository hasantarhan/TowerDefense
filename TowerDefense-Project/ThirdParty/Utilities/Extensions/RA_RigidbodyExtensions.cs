
using UnityEngine;
namespace RedAxeGames.Extensions
{
    public static class RA_RigidbodyExtensions
    {
        public static void AddImplosionForce(this Rigidbody rb, float implosionForce, Vector3 position, float explosionRadius, float upwardsModifier = 0.0f, ForceMode mode = ForceMode.Force)
        {
            Vector3 direction = position - rb.transform.position;
            float distance = direction.magnitude;
            if (distance == 0.0f) return;
            direction.Normalize();
            Vector3 upwards = Vector3.up * upwardsModifier;
            float force = (1.0f - Mathf.Clamp01(distance / explosionRadius)) * implosionForce;
            rb.AddForce(direction * force + upwards, mode);
        }
    }
}