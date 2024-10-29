using UnityEngine;

namespace MySample
{
    public class MoveWall : MonoBehaviour
    {
        #region Variables
        [SerializeField]private float moveSpeed = 5f;

        [SerializeField] private float moveTime = 1f;
        private float countdown = 0f;

        //이동방향 좌/우
        [SerializeField] private float dir = 1f;
        #endregion

        private void Start()
        {
            //초기화
            countdown = moveTime;
        }

        void Update()
        {
            //좌우이동 타이머 설정
            if(countdown <= 0f)
            {
                //타이머 액션 - 방향 전환
                dir *= -1;

                //초기화
                countdown = moveTime;
            }
            countdown -= Time.deltaTime;

            transform.Translate(Vector3.right * dir * moveSpeed * Time.deltaTime,Space.World);

        }
    }
}