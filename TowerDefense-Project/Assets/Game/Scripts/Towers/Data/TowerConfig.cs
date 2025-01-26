using UnityEngine;
using UnityEngine.Serialization;
namespace Game
{
    [CreateAssetMenu(fileName = "TowerConfig", menuName = "Game/Tower Config", order = 0)]
    public class TowerConfig : ScriptableObject
    {
        public enum TowerType { Basic, Slow, Fast }

        [SerializeField] private TowerType type;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private GameObject towerPrefab;
        [SerializeField] private float damage;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float range;
        [SerializeField] private float fireRate;
    
        public TowerType Type => type;
        public GameObject TowerPrefab => towerPrefab;
        public Bullet BulletPrefab => bulletPrefab;
        public float Damage => damage;
        public float BulletSpeed => bulletSpeed;
        public float Range => range;
        public float FireRate => fireRate;
    }
}