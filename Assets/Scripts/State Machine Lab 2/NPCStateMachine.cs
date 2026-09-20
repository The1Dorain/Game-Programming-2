using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Core.FSM
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NPCStateMachine : MonoBehaviour
    {
        StateMachine stateMachine;

        private void Awake()
        {
            // This is the Creation of the StateMachine
            stateMachine = new StateMachine();
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            NavMeshAgent agent = GetComponent<NavMeshAgent>();

            // We then need to create instatnces for contrete stateNodes
            PatrolState patrol = new PatrolState(renderer, agent);
            HarvestState harvest = new HarvestState(renderer, agent);
            RestState rest = new RestState(renderer, agent);
            GuardState guard = new GuardState(renderer, agent);
            PlantingState plant = new PlantingState(renderer, agent);

            stateMachine.AddTransition(rest, patrol, new FuncPredicate(() => Keyboard.current.pKey.wasPressedThisFrame));
            stateMachine.AddTransition(rest, harvest, new FuncPredicate(() => Keyboard.current.hKey.wasPressedThisFrame));
            stateMachine.AddTransition(rest, guard, new FuncPredicate(() => Keyboard.current.gKey.wasPressedThisFrame));
            stateMachine.AddTransition(rest, plant, new FuncPredicate(() => Keyboard.current.sKey.wasPressedThisFrame));

            stateMachine.AddTransition(harvest, rest, new FuncPredicate(() => Keyboard.current.rKey.wasPressedThisFrame));
            stateMachine.AddTransition(patrol, rest, new FuncPredicate(() => Keyboard.current.rKey.wasPressedThisFrame));
            stateMachine.AddTransition(guard, rest, new FuncPredicate(() => Keyboard.current.rKey.wasPressedThisFrame));
            stateMachine.AddTransition(plant, rest, new FuncPredicate(() => Keyboard.current.rKey.wasPressedThisFrame));

            stateMachine.AddTransition(harvest, plant, new FuncPredicate(() => Keyboard.current.sKey.wasPressedThisFrame)); // Add future code to check if you have available seeds after harvest, then run code.

            stateMachine.SetState(rest);
        }

        private void Update()
        {
            stateMachine.Update();
        }
    }
}
