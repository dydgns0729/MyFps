using System.Collections;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class BFirstTrigger : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI textBox;
        public GameObject thePlayer;
        public GameObject arrowObject;
        [SerializeField] string sequence = "Looks like a weapon on that table";
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }

        IEnumerator PlaySequence()
        {


            //플레이어 캐릭터 비활성화
            thePlayer.SetActive(false);
            //대사 출력
            textBox.text = sequence;
            textBox.gameObject.SetActive(true);
            //1초 대기
            yield return new WaitForSeconds(1f);
            //화살표 표시
            arrowObject.SetActive(true);
            //1초 대기
            yield return new WaitForSeconds(1f);
            //대사 초기화 및 없애기
            textBox.text = "";
            textBox.gameObject.SetActive(false);
            //플레이어 캐릭터 활성화
            thePlayer.SetActive(true);

            //트리거 비활성화
            this.transform.GetComponent<BoxCollider>().enabled = false;
        }
    }
}