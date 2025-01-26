using UnityEngine;
namespace Game
{
    [CreateAssetMenu(fileName = "TowerConfig", menuName = "Game/Tower Config", order = 0)]
    public class TowerConfig : ScriptableObject
    {
        [SerializeField] private Bullet bullet;
        [SerializeField] private Tower towerObject;
        [SerializeField] private float damage;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float range;
        [SerializeField] private float fireRate;
        public float Damage => damage;
        public float BulletSpeed => bulletSpeed;
        public float Range => range;
        public float FireRate => fireRate;
    }
}