using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    public class GuardState : BaseState
    {
        public GuardState(MeshRenderer renderer, NavMeshAgent agent) : base(renderer, agent)
        {
        }

        public override void Enter()
        {
            meshRenderer.material.color = Color.white;
            // Future code for standing guard.
        }
    }
}
