using UnityEngine;
namespace Hasan.Misc
{
    public class VelocityCalculator
    {
        private readonly Transform _transform;

        private bool firstWork;
        private Vector3 lastPosition;
        public float speed;

        public VelocityCalculator(Transform transform)
        {
            _transform = transform;
        }

        public Vector3 Motion { get; private set; }

        public void Update()
        {
            if (!firstWork)
            {
                lastPosition = _transform.position;
                firstWork = true;
            }

            var position = _transform.position;
            Motion = (position - lastPosition) / Time.deltaTime;
            speed = Motion.magnitude;
            lastPosition = position;
        }
    }
}