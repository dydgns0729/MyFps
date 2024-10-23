using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class DOpening : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;

        public GameObject thePlayer;
        public TextMeshProUGUI textBox;
        #endregion
        void Start()
        {
            //마우스 커서 상태 설정
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            StartCoroutine(SequencePlay());
        }

        IEnumerator SequencePlay()
        {
            //플레이어 움직임 비활성화
            thePlayer.GetComponent<FirstPersonController>().enabled = false;
            //배경음 시작
            AudioManager.Instance.PlayBGM("PlayBGM");
            //시퀀스 텍스트 초기화
            textBox.gameObject.SetActive(true);
            textBox.text = "";

            //1초후 페이드인 효과 시작
            yield return new WaitForSeconds(1f);
            fader.FromFade();

            //플레이어 움직임 활성화
            yield return new WaitForSeconds(1f);
            textBox.gameObject.SetActive(false);
            thePlayer.GetComponent<FirstPersonController>().enabled = true;

        }

    }
}