using UnityEngine;

namespace My_DOTS_Test_Proj.Scripts.UsualUnityComponents
{
    public class ShootPopup : MonoBehaviour
    {
        private float _destroyTimer = 3f;


        private void Update()
        {
            float moveSpeed = 2f;
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;

            _destroyTimer -= Time.deltaTime;

            if (_destroyTimer < 0)
                Destroy(this.gameObject);

        }
    }
}
