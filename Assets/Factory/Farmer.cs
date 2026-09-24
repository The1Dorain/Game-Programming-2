using Core.FSM;
using UnityEngine;
using UnityEngine.AI;

public class Farmer : MonoBehaviour, IEntity, IStateMachine, ITask
{
    StateMachine stateMachine;
    [SerializeField] private VoidEventChannel harvestEvent;
    [SerializeField] private bool isHarvestReady = false;

    private void Awake()
    {
        // This is the Creation of the StateMachine
        stateMachine = new StateMachine();
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        // We then need to create instatnces for contrete stateNodes
        HarvestState harvest = new HarvestState(renderer, agent);
        RestState rest = new RestState(renderer, agent);

        stateMachine.AddTransition(rest, harvest, new FuncPredicate(() => isHarvestReady));

        stateMachine.AddTransition(harvest, rest, new FuncPredicate(() => !isHarvestReady));

        //stateMachine.AddTransition(harvest, plant, new FuncPredicate(() => Keyboard.current.sKey.wasPressedThisFrame)); // Add future code to check if you have available seeds after harvest, then run code.

        stateMachine.SetState(rest);

        harvestEvent.OnEventRaised += TransitionToHarvest;
    }

    private void Update()
    {
        stateMachine.Update();
    }

    private void OnDisable()
    {
        harvestEvent.OnEventRaised -= TransitionToHarvest;
    }

    private bool CheckHarvestPoint(Vector3 harvestLocation)
    {
        return isHarvestReady;
    }

    private void TransitionToHarvest()
    {

        isHarvestReady = !isHarvestReady;
    }
}