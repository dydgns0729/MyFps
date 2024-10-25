using UnityEngine;

namespace MyFps
{
    public class FlyingObject : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float velocity = 1f;   //사운드플레이 기준이 되는 속도
        #endregion

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.relativeVelocity.magnitude > velocity)
            {
                //충돌체를 가진 개체에 부딪히는 사운드 재생
                AudioManager.Instance.Play("CupFall");
            }
        }
    }
}