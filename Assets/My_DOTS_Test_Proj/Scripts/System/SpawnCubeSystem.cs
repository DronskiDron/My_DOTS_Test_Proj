using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace My_DOTS_Test_Proj.Scripts.Components.System
{
    public partial class SpawnCubeSystem : SystemBase
    {
        protected override void OnCreate()
        {
            RequireForUpdate<SpawnCubesConfig>();
        }


        protected override void OnUpdate()
        {
            this.Enabled = false;

            SpawnCubesConfig spawnCubesConfig = SystemAPI.GetSingleton<SpawnCubesConfig>();

            for (int i = 0; i < spawnCubesConfig.AmountToSpawn; i++)
            {
                Entity spawnedEntity = EntityManager.Instantiate(spawnCubesConfig.CubePrefabEntity);
                SystemAPI.SetComponent(spawnedEntity, new LocalTransform
                {
                    Position = new float3(UnityEngine.Random.Range(-10f, +5), 0.6f, UnityEngine.Random.Range(-4f, +7)),
                    Rotation = quaternion.identity,
                    Scale = 1f
                });
            }
        }


        // protected override void OnUpdate()
        // {
        //     this.Enabled = false;

        //     SpawnCubesConfig spawnCubesConfig = SystemAPI.GetSingleton<SpawnCubesConfig>();

        //     for (int i = 0; i < spawnCubesConfig.AmountToSpawn; i++)
        //     {
        //         Entity spawnedEntity = EntityManager.Instantiate(spawnCubesConfig.CubePrefabEntity);
        //         EntityManager.SetComponentData(spawnedEntity, new LocalTransform
        //         {
        //             Position = new float3(UnityEngine.Random.Range(-10f, +5), 0.6f, UnityEngine.Random.Range(-4f, +7)),
        //             Rotation = quaternion.identity,
        //             Scale = 1f
        //         });
        //     }
        // }
    }
}
