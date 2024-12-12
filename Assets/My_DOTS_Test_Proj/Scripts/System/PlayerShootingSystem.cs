using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace My_DOTS_Test_Proj.Scripts.Components.System
{
    public partial class PlayerShootingSystem : SystemBase
    {
        protected override void OnCreate()
        {
            RequireForUpdate<Player>();
        }


        protected override void OnUpdate()
        {
            if (!Input.GetKeyDown(KeyCode.Space))
            {
                return;
            }

            SpawnCubesConfig spawnCubesConfig = SystemAPI.GetSingleton<SpawnCubesConfig>();

            EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);

            foreach (RefRO<LocalTransform> localTransform in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<Player>())
            {
                Entity spawnedEntity = entityCommandBuffer.Instantiate(spawnCubesConfig.CubePrefabEntity);
                entityCommandBuffer.SetComponent(spawnedEntity, new LocalTransform
                {
                    Position = localTransform.ValueRO.Position,
                    Rotation = quaternion.identity,
                    Scale = 1f
                });
            }

            entityCommandBuffer.Playback(EntityManager);
        }
    }
}
