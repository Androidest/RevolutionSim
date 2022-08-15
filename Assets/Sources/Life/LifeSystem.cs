using Entitas;
using UnityEngine;

public sealed class LifeSystem : IInitializeSystem
{
    readonly Contexts _contexts;

    public LifeSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.AddPosition(new Vector2(0, 0));
        entity.AddDirection(0);
        entity.AddAsset("Piece" + Rand.inst.Int(6));
    }
}
