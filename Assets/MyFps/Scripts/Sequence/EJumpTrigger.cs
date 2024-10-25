using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class EJumpTrigger : MonoBehaviour
    {
        #region Variables

        public GameObject thePlayer;

        public GameObject activityObject;

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag != "Player") return;
            StartCoroutine(PlaySequence());
        }

        IEnumerator PlaySequence()
        {
            //플레이 캐릭터 비활성화
            thePlayer.GetComponent<FirstPersonController>().enabled = false;
            activityObject.SetActive(true);             //연출용 오브젝트 활성화
            yield return new WaitForSeconds(1f);
            //다시 활성화
            thePlayer.GetComponent<FirstPersonController>().enabled = true;
            activityObject.SetActive(false);

            //트리거 충돌체, 연출용 오브젝트 비활성화 - 킬
            Destroy(gameObject);
            Destroy(activityObject);

        }
    }
}