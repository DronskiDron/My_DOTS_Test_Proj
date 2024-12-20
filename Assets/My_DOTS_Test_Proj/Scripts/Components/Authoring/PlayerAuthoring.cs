using Unity.Entities;
using UnityEngine;

namespace My_DOTS_Test_Proj.Scripts.Components
{
    public class PlayerAuthoring : MonoBehaviour
    {
        private class Baker : Baker<PlayerAuthoring>
        {
            public override void Bake(PlayerAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new Player());
            }
        }
    }


    public struct Player : IComponentData
    {

    }
}
