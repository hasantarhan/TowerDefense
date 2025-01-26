using System;
using UnityEngine;
namespace Game
{
    public class Bullet : MonoBehaviour
    {
        [HideInInspector] public float damage;
        private void OnCollisionEnter(Collision other)
        {
            
        }
    }
}