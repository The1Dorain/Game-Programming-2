using UnityEngine;
using UnityEngine.AI;

namespace Core.FSM
{
    public class PlantingState : BaseState
    {
        public PlantingState(MeshRenderer renderer, NavMeshAgent agent) : base(renderer, agent) { }

        public override void Enter()
        {
            meshRenderer.material.color = Color.darkGreen;
            // Future code for planting seeds.
        }
    }
}
