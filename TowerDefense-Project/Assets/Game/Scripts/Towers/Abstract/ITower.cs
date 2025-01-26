namespace Game.Domain
{
    public interface ITower
    {
        void Attack(IEnemy enemy);
        float Range { get; }
        float Damage { get; }
    }
}