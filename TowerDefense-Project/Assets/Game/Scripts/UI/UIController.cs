using Game.Domain;
using Game.Scripts.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
namespace Game
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private TextMeshProUGUI enemyCountText;
        [SerializeField] private TextMeshProUGUI towerCountText;

        private ISpawner spawner;
        private GameStateMachine stateMachine;
        private GameConfig gameConfig;
        public void ShowStartButton() => startButton.gameObject.SetActive(true);
        public void HideStartButton() => startButton.gameObject.SetActive(false);

        [Inject]
        public void Construct(GameStateMachine stateMachine, GameConfig gameConfig)
        {
            this.stateMachine = stateMachine;
            this.gameConfig = gameConfig;
            gameConfig.runtimeGameData.OnDiedEnemyCountChanged += EnemyCountChanged;
            gameConfig.runtimeGameData.OnTowerCountChanged += OnTowerCountChanged;
        }
        
        private void OnTowerCountChanged(int obj)
        {
            towerCountText.text = $"Towers: {obj}/{gameConfig.maxTowerCount}";
        }

        private void EnemyCountChanged(int obj)
        {
            enemyCountText.text = $"Enemies: {obj}/ {gameConfig.runtimeGameData.WaveEnemyCount} ";
        }
        private void StartSpawning()
        {
            stateMachine.ChangeState(GameStateType.Combat);
            HideStartButton();
        }
        private void Start()
        {
            OnTowerCountChanged( gameConfig.runtimeGameData.TowerCount);
            EnemyCountChanged(gameConfig.runtimeGameData.DiedEnemyCount);
            ShowStartButton();
            startButton.onClick.AddListener(StartSpawning);
        }
    }
}