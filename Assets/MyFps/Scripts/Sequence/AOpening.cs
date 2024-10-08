using System.Collections;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class AOpening : MonoBehaviour
    {
        #region Variables

        public GameObject thePlayer;

        public SceneFader fader;
        float delayTime;
        [SerializeField] float setDelayTime = 1f;

        //Sequence UI
        public TextMeshProUGUI textBox;
        [SerializeField] string sequence = "I need get out of here...";

        #endregion
        private void Awake()
        {
            delayTime = setDelayTime;
        }
        private void Start()
        {
            StartCoroutine(PlaySequence());
        }

        IEnumerator PlaySequence()
        {
            //0.플레이 캐릭터 비 활성화
            thePlayer.SetActive(false);

            //1.페이드인 연출(1초 대기후 페인드인 효과)
            fader.FromFade(delayTime);  //delayTime + 화면이 보이는 시간(1초)

            //2.화면 하단에 시나리오 텍스트 화면 출력(3초)
            //  (I need get out of here)
            textBox.gameObject.SetActive(true);
            textBox.text = sequence;

            //3. 3초후에 시나리오 텍스트 없어진다
            yield return new WaitForSeconds(3f);
            textBox.gameObject.SetActive(false);

            //4.플레이 캐릭터 활성화
            thePlayer.SetActive(true);
        }
    }
}