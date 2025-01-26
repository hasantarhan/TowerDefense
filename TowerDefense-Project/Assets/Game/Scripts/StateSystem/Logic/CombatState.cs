using Game.Domain;
using UnityEngine;
using VContainer;
namespace Game
{
    public class CombatState : IGameState
    {
        private readonly EnemySpawner spawner;

        [Inject]
        public CombatState(EnemySpawner spawner)
        {
            this.spawner = spawner;
        }

        public void Enter() => spawner.StartSpawning();
        public void Exit() => spawner.StopSpawning();
        public void Update() { }
    }
}