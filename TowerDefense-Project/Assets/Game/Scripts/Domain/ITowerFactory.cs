using UnityEngine;
namespace Game.Domain
{
    public interface ITowerFactory
    {
        T CreateTower<T>(Vector3 position) where T : MonoBehaviour, ITower;
    }
}