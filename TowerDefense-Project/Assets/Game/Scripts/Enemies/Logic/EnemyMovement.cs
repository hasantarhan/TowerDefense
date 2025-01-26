using System;
using UnityEngine;
using VContainer;
namespace Game
{
    public class EnemyMovement : MonoBehaviour
    {
        private Path path;
        public int currentWaypointIndex;
        [SerializeField] private float speed = 3f;
        private const float distance = 0.1f;

        [Inject]
        public void Construct(Path path)
        {
            this.path = path;
            currentWaypointIndex = 0;
        }
        private void OnEnable()
        {
            currentWaypointIndex = 0;
            transform.position = path.GetPoint(currentWaypointIndex);
        }
        private void Start()
        {
            transform.position = path.GetPoint(currentWaypointIndex);
        }
        void Update()
        {
            if (path == null || path.HasReachedEnd(currentWaypointIndex)) return;

           var nextPoint = path.GetPoint(currentWaypointIndex);
           if (Vector3.Distance(transform.position,nextPoint) < distance)
           {
               currentWaypointIndex++;
           }
           else
           {
               transform.position = Vector3.MoveTowards(transform.position, nextPoint, speed * Time.deltaTime);
           }

        }
    }
}