using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self)]
public sealed class PositionComponent : IComponent
{
    public UnityEngine.Vector2 value;
}
