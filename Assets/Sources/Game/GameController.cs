using Entitas;
using UnityEngine;

namespace SimCore
{
    public class GameController : MonoBehaviour
    {
        Systems _systems;

        void Awake()
        {
            Rand.inst = new Rand(12345);
            _systems = new GameSystems(Contexts.sharedInstance);
        }

        void Start()
        {
            _systems.Initialize();
        }

        void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }
    }
}