using UnityEngine;

public class GameController : MonoBehaviour
{
    PhysicsSystem physicsSystem;

    void Start()
    {
        var contexts = new Contexts();
        var e = contexts.game.CreateEntity();
        e.AddPosition(new Vector2(0,0));

        physicsSystem = new PhysicsSystem(contexts);
    }

    void FixedUpdate()
    {
        physicsSystem.Execute();
    }
}
