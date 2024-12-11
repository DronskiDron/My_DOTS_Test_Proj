using Unity.Entities;
using Unity.Transforms;

namespace My_DOTS_Test_Proj.Scripts.Components.System.Aspects
{
    public readonly partial struct RotatingMovingCubeAspect : IAspect
    {
        private readonly RefRW<LocalTransform> _localTransform;
        private readonly RefRO<RotateSpeed> _rotateSpeed;
        private readonly RefRO<Movement> _movement;


        public void MoveAndRotate(float deltaTime)
        {
            _localTransform.ValueRW = _localTransform.ValueRO.RotateY(_rotateSpeed.ValueRO.Value * deltaTime);
            _localTransform.ValueRW = _localTransform.ValueRO.Translate(_movement.ValueRO.MovementVector * deltaTime);
        }
    }
}
