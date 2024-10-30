using UnityEngine;

namespace MyFps
{
    public class HEnemyZoneOutTrigger : MonoBehaviour
    {
        #region Variables
        public Transform gunMan;

        //private Enemy enemy;

        public GameObject enemyZoneIn;
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            this.gameObject.SetActive(false);
            if (gunMan == null) return;

            //건맨 추격 시작 
            if (other.tag == "Player")
            {
                gunMan.GetComponent<Enemy>().GoStartPosition();
                enemyZoneIn.SetActive(true);
            }

        }

        //private void OnTriggerExit(Collider other)
        //{
        //    //In 트리거 활성화 
        //    this.gameObject.SetActive(false);
        //    enemyZoneIn.SetActive(true);
        //}
    }
}