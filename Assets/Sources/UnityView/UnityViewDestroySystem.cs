using Entitas;
using SimCore;
using System.Collections.Generic;
using UnityEngine;

public sealed class UnityViewDestroySystem : ReactiveSystem<GameEntity>
{
    public UnityViewDestroySystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroy);
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.hasGameObject;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var viewBehavior = e.gameObject.value.GetComponent<UnityViewBehavior>();
            viewBehavior.OnUnlink();
            e.gameObject.Unlink(e);
            e.ReplaceGameObject(null);
        }
    }
}
