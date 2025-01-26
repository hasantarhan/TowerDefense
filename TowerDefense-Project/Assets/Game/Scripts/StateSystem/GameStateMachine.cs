using System.Collections.Generic;
using Game.Domain;
using VContainer;
namespace Game
{
    public class GameStateMachine
    {
        private readonly Dictionary<GameStateType, IGameState> states;
        private IGameState currentState;

        [Inject]
        public GameStateMachine(BuildingState buildingState, CombatState combatState)
        {
            states = new Dictionary<GameStateType, IGameState>
            {
                {
                    GameStateType.Building, buildingState
                },
                {
                    GameStateType.Combat, combatState
                }
            };

            ChangeState(GameStateType.Building);
        }

        public void ChangeState(GameStateType newState)
        {
            currentState?.Exit();
            currentState = states[newState];
            currentState.Enter();
        }

        public void Update() => currentState?.Update();
    }
}