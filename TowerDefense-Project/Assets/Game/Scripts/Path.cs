using System;
using System.Linq;
using UnityEngine;
namespace Game
{
    using UnityEngine;

    public class Path : MonoBehaviour
    {
        public Transform[] waypoints;
        public Vector3 GetFirstWaypoint() => waypoints[0].position;
        public bool HasReachedEnd(int index) => index >= waypoints.Length;

        private void Awake()
        {
            waypoints = GetComponentsInChildren<Transform>();
            var wayPointList = waypoints.ToList();
            wayPointList.Remove(transform);
            waypoints = wayPointList.ToArray();
        }
        public Vector3 GetPoint(int index)
        {
            return waypoints[index].position;
        }

    }
}