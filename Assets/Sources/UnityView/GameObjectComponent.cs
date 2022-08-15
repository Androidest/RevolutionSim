using Entitas;
using System;

public sealed class GameObjectComponent : IComponent
{
    public UnityEngine.GameObject value;

    internal void Unlink(GameEntity e)
    {
        throw new NotImplementedException();
    }
}