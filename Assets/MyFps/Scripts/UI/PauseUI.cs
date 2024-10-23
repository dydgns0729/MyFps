using UnityEngine;
using StarterAssets;

namespace MyFps
{
    public class PauseUI : MonoBehaviour
    {
        #region Variables
        public GameObject pauseUI;
        private GameObject thePlayer;

        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";
        #endregion
        private void Awake()
        {
            //참조
            thePlayer = GameObject.Find("Player");
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Toggle();
            }
        }
        public void Toggle()
        {

            pauseUI.SetActive(!pauseUI.activeSelf);
            if (pauseUI.activeSelf) //pause 창이 오픈 될때
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                thePlayer.GetComponent<FirstPersonController>().enabled = false;

                Time.timeScale = 0f;
            }
            else                    //pause 창이 닫힐때
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = false;
                thePlayer.GetComponent<FirstPersonController>().enabled = true;

                Time.timeScale = 1f;
            }
        }

        public void Menu()
        {
            Time.timeScale = 1f;

            //씬 종료 처리
            AudioManager.Instance.StopBGM();

            //메인메뉴로 이동
            fader.FadeTo(loadToScene);

            //Debug.Log("Goto Menu");
        }
    }
}