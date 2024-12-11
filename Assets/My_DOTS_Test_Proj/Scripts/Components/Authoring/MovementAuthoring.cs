using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace My_DOTS_Test_Proj.Scripts.Components
{
    public class MovementAuthoring : MonoBehaviour
    {
        private class Baker : Baker<MovementAuthoring>
        {
            public override void Bake(MovementAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new Movement
                {
                    MovementVector = new float3(UnityEngine.Random.Range(-1f, +1f), 0, UnityEngine.Random.Range(-1f, +1f))
                });
            }
        }
    }


    public struct Movement : IComponentData
    {
        public float3 MovementVector;
    }
}
