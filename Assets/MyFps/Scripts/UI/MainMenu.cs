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
        #endregion

        private void Start()
        {
            fader.FromFade();
        }

        public void NewGame()
        {
            fader.FadeTo(loadtoScene);
        }

        public void LoadGame()
        {
            Debug.Log("Load Game");
        }

        public void Options()
        {
            Debug.Log("Options");
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