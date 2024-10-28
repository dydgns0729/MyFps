using UnityEngine;

namespace MyFps
{
    public class FExitTrigger : MonoBehaviour
    {
        #region Variabels
        public SceneFader fader;
        [SerializeField] string loadToScene = "MainMenu";
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            PlaySequence();
        }

        void PlaySequence()
        {
            //씬 클리어 처리
            //배경음 종료
            AudioManager.Instance.StopBGM();

            //씬 클리어 보상, 데이터 처리
            
            //메인 메뉴로 이동
            fader.FadeTo(loadToScene);
        }
    }
}