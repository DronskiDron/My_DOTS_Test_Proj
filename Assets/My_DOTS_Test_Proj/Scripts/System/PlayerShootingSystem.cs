using System;
using My_DOTS_Test_Proj.Scripts.Root;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace My_DOTS_Test_Proj.Scripts.Components.System
{
    public partial class PlayerShootingSystem : SystemBase
    {
        public event EventHandler OnShoot;


        protected override void OnCreate()
        {
            RequireForUpdate<Player>();
        }


        protected override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Entity playerEntity = SystemAPI.GetSingletonEntity<Player>();
                EntityManager.SetComponentEnabled<Stunned>(playerEntity, true);
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                Entity playerEntity = SystemAPI.GetSingletonEntity<Player>();
                EntityManager.SetComponentEnabled<Stunned>(playerEntity, false);
            }

            if (!Input.GetKeyDown(KeyCode.Space))
            {
                return;
            }

            SpawnCubesConfig spawnCubesConfig = SystemAPI.GetSingleton<SpawnCubesConfig>();

            EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);

            foreach ((RefRO<LocalTransform> localTransform, Entity entity) in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<Player>()
            .WithDisabled<Stunned>().WithEntityAccess())
            {
                Entity spawnedEntity = entityCommandBuffer.Instantiate(spawnCubesConfig.CubePrefabEntity);
                entityCommandBuffer.SetComponent(spawnedEntity, new LocalTransform
                {
                    Position = localTransform.ValueRO.Position,
                    Rotation = quaternion.identity,
                    Scale = 1f
                });

                OnShoot?.Invoke(entity, EventArgs.Empty);

                PlayerShootManager.Instance.PlayerShoot(localTransform.ValueRO.Position);
            }

            entityCommandBuffer.Playback(EntityManager);
        }


        // protected override void OnUpdate()
        // {
        //     if (!Input.GetKeyDown(KeyCode.Space))
        //     {
        //         return;
        //     }

        //     SpawnCubesConfig spawnCubesConfig = SystemAPI.GetSingleton<SpawnCubesConfig>();

        //     foreach (RefRO<LocalTransform> localTransform in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<Player>())
        //     {
        //         Entity spawnedEntity = EntityManager.Instantiate(spawnCubesConfig.CubePrefabEntity);
        //         SystemAPI.SetComponent(spawnedEntity, new LocalTransform
        //         {
        //             Position = localTransform.ValueRO.Position,
        //             Rotation = quaternion.identity,
        //             Scale = 1f
        //         });
        //     }
        // }
    }
}
