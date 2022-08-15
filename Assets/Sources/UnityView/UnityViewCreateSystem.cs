using Entitas;
using Entitas.Unity;
using SimCore;
using System.Collections.Generic;
using UnityEngine;

public sealed class UnityViewCreateSystem : ReactiveSystem<GameEntity>
{
    readonly Transform _parent;

    public UnityViewCreateSystem(Contexts contexts) : base(contexts.game)
    {
        _parent = new GameObject("Views").transform;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Asset);
    }
    protected override bool Filter(GameEntity entity)
    {
        return !entity.hasGameObject;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var prefab = Resources.Load<GameObject>("Prefabs/" + e.asset.value);
            var gameObject = Object.Instantiate(prefab, _parent);

            var viewBehavior = gameObject.GetComponent<UnityViewBehavior>();
            viewBehavior.OnLink(e);
            gameObject.Link(e);
            e.AddGameObject(gameObject);
        }
    }
}
