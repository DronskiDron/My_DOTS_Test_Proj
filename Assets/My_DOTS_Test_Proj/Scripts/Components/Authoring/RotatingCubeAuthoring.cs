using Unity.Entities;
using UnityEngine;

namespace My_DOTS_Test_Proj.Scripts.Components
{
    public class RotatingCubeAuthoring : MonoBehaviour
    {
        private class Baker : Baker<RotatingCubeAuthoring>
        {
            public override void Bake(RotatingCubeAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new RotatingCube());
            }
        }
    }


    public struct RotatingCube : IComponentData
    {

    }
}
