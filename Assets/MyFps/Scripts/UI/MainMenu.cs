using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        [SerializeField] string loadtoScene = "MainScene01";
        public SceneFader fader;

        private AudioManager audioManager;
        #endregion

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private void Start()
        {
            fader.FromFade();

            //참조
            audioManager = AudioManager.Instance;

            //BGM 플레이
            audioManager.PlayBGM("MenuBGM");
        }

        public void NewGame()
        {
            audioManager.Stop(audioManager.BgmSound);
            audioManager.Play("MenuButton");
            fader.FadeTo(loadtoScene);
        }

        public void LoadGame()
        {
            Debug.Log("Load Game");
        }

        public void Options()
        {
            Debug.Log("Options");
            audioManager.PlayBGM("PlayBGM");
        }

        public void Credits()
        {
            Debug.Log("Credits");
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}