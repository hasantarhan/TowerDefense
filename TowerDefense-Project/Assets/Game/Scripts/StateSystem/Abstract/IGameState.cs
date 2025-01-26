namespace Game.Domain
{
    public interface IGameState
    {
        void Enter();
        void Exit();
        void Update();
    }

    public enum GameStateType
    {
        Building,
        Combat
    }
}