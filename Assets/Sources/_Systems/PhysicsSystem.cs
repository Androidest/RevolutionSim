using Entitas;
using UnityEngine;

public sealed class PhysicsSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> entities;

    public PhysicsSystem(Contexts constexs)
    {
        entities = constexs.game.GetGroup(GameMatcher.Position);
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            var pos = e.position.value;
            e.ReplacePosition(new Vector2(pos.x + 0.01f, pos.y));
        }
    }
}
