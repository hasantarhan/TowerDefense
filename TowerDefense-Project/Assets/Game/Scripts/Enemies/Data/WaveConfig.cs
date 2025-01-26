using UnityEngine;
namespace Game.Scripts.Enemies.Data
{
    [CreateAssetMenu(fileName = "Wave Data", menuName = "Game/Wave", order = 0)]
    public class WaveConfig : ScriptableObject
    {
        public float spawnInterval=1;
        public int enemyCount=10;
        
    }
}