using Game.Domain;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
namespace Game
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        private ISpawner spawner;
        private GameStateMachine stateMachine;
        public void ShowStartButton() => startButton.gameObject.SetActive(true);
        public void HideStartButton() => startButton.gameObject.SetActive(false);

        [Inject]
        public void Construct(GameStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        private void StartSpawning()
        {
            stateMachine.ChangeState(GameStateType.Combat);
            HideStartButton();
        }
        private void Start()
        {
            ShowStartButton();
            startButton.onClick.AddListener(StartSpawning);
        }
    }
}