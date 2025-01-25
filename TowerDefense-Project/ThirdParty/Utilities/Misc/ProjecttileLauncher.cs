using UnityEngine;
namespace RA_Utilities.Misc
{
    public static class ProjecttileLauncher
    {
        public static LaunchData CalculateLaunchData(Vector3 from, Vector3 target, float height = 1)
        {
            float gravity = Physics.gravity.y;
            float displacementY = target.y - from.y;
            Vector3 displacementXZ = new Vector3(target.x - from.x, 0, target.z - from.z);
            float time = Mathf.Sqrt(-2 * height / gravity) + Mathf.Sqrt(2 * (displacementY - height) / gravity);
            Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * height);
            Vector3 velocityXZ = displacementXZ / time;
            return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);
        }
        public static Vector3 CalculateVelocity(Vector3 from, Vector3 target, float height = 1)
        {
            return CalculateLaunchData(from, target, height).initialVelocity;
        }

        public struct LaunchData
        {
            public readonly Vector3 initialVelocity;
            public readonly float timeToTarget;

            public LaunchData(Vector3 initialVelocity, float timeToTarget)
            {
                this.initialVelocity = initialVelocity;
                this.timeToTarget = timeToTarget;
            }
        }
    }
}