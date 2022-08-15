public sealed class GameSystems : Feature
{
    public GameSystems(Contexts contexts)
    {
        Add(new LifeSystem(contexts));
        Add(new PhysicsSystem(contexts));
        Add(new UnityViewCreateSystem(contexts));
        Add(new UnityViewDestroySystem(contexts));

        // Events (Generated)
        Add(new GameEventSystems(contexts));
    }
}