using UnityEngine;

namespace MyFps
{
    public class GEnemyZoneInTrigger : MonoBehaviour
    {
        #region Variables
        public Transform gunMan;

        //private Enemy enemy;

        public GameObject enemyZoneOut; //Out 트리거
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            this.gameObject.SetActive(false);
            if (gunMan == null) return;
            
                //건맨 추격 시작 
                if (other.tag == "Player")
                {
                    gunMan.GetComponent<Enemy>().SetState(EnemyState.E_Chase);
                    enemyZoneOut.SetActive(true);
                }
            
        }
        //private void OnTriggerExit(Collider other)
        //{
        //    //Out 트리거 활성화 
        //    this.gameObject.SetActive(false);
        //    enemyZoneOut.SetActive(true);
        //}
    }
}