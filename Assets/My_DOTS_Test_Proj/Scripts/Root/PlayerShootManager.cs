using System;
using My_DOTS_Test_Proj.Scripts.Components.System;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace My_DOTS_Test_Proj.Scripts.Root
{
    public class PlayerShootManager : MonoBehaviour
    {
        public static PlayerShootManager Instance { get; private set; }

        [SerializeField] private GameObject _shootPopupPrefab;


        private void Awake()
        {
            Instance = this;
        }


        public void PlayerShoot(Vector3 playerPosition)
        {
            Instantiate(_shootPopupPrefab, playerPosition, Quaternion.identity);
        }


        // private void Start()
        // {
        //     PlayerShootingSystem playerShootingSystem =
        //      World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<PlayerShootingSystem>();


        //     playerShootingSystem.OnShoot += PlayerShootingSystem_OnShoot;
        // }


        // private void PlayerShootingSystem_OnShoot(object sender, EventArgs e)
        // {
        //     Entity playerEntity = (Entity)sender;
        //     LocalTransform localTransform =
        //      World.DefaultGameObjectInjectionWorld.EntityManager.GetComponentData<LocalTransform>(playerEntity);
        //     Instantiate(_shootPopupPrefab, localTransform.Position, Quaternion.identity);
        // }
    }
}
