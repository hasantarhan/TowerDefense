using Game.Domain;
using UnityEngine;
using VContainer;
namespace Game
{
    public class BuildingState : IGameState
    {
        private readonly TowerPlacementController towerPlacement;
    

        [Inject]
        public BuildingState(TowerPlacementController towerPlacement)
        {
            this.towerPlacement = towerPlacement;
        }

        public void Enter()
        {
            towerPlacement.EnablePlacement();
        }

        public void Exit()
        {
            towerPlacement.DisablePlacement();
        }

        public void Update() { }
    }
}