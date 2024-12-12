using Unity.Entities;
using UnityEngine;

namespace My_DOTS_Test_Proj.Scripts.Components
{
    public class StunnedAuthoring : MonoBehaviour
    {
        private class Baker : Baker<StunnedAuthoring>
        {
            public override void Bake(StunnedAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);

                AddComponent(entity, new Stunned());
                SetComponentEnabled<Stunned>(entity, false);
            }
        }
    }


    public struct Stunned : IComponentData, IEnableableComponent
    {

    }
}