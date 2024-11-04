using UnityEngine;

namespace MyFps
{
    public class GameOver : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";
        #endregion

        private void Start()
        {
            //마우스 커서 상태 설정
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //페이드인 효과
            fader.FromFade();
        }

        public void Retry()
        {
            fader.FadeTo(PlayerStats.Instance.NowSceneNumber);
        }

        public void Menu()
        {
            fader.FadeTo(loadToScene);
        }
    }
}