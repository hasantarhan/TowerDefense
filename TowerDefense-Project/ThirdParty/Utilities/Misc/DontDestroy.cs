using UnityEngine;
namespace Hasan.Misc
{
    [DefaultExecutionOrder(-2)]
    public class DontDestroy : MonoBehaviour
    {
        private static DontDestroy _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
            Debug.Log("Game version : " + Application.version);
        }
    }
}