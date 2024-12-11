using My_DOTS_Test_Proj.Scripts.Components.System.Aspects;
using Unity.Entities;

namespace My_DOTS_Test_Proj.Scripts.Components.System
{
    public partial struct HandleCubesSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            foreach (RotatingMovingCubeAspect rotatingMovingCubeAspect
            in SystemAPI.Query<RotatingMovingCubeAspect>().WithAll<RotatingCube>())
            {
                rotatingMovingCubeAspect.MoveAndRotate(SystemAPI.Time.DeltaTime);
            }
        }
    }
}
