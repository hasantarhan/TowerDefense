using UnityEngine;
using UnityEngine.UI;
namespace Hasan.Misc
{
    public class UIDynamicShadow : MonoBehaviour
    {
        private Shadow shadow;
        public float shadowDistance = 5;
        public Vector2 shadowDirection = Vector2.down;
        private void Awake()
        {
            shadow = GetComponent<Shadow>();
        }
        private void LateUpdate()
        {
            Vector2 globalDown = shadowDirection * shadowDistance;
            float rotationZ = transform.eulerAngles.z;
            Quaternion inverseRotation = Quaternion.Euler(0, 0, -rotationZ);
            Vector2 localDown = inverseRotation * globalDown;
            shadow.effectDistance = localDown;
        }
    }
}