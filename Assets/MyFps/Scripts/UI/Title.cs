using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class Title : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";

        private bool isAnyKey;
        public GameObject anykeyText;
        #endregion

        private void Start()
        {
            //페이드인 효과
            fader.FromFade();

            isAnyKey = false;

            StartCoroutine(TitleProcess());
        }

        private void Update()
        {
            if (Input.anyKey && isAnyKey)
            {
                GotoMenu();
            }
        }

        private void GotoMenu()
        {
            StopAllCoroutines();

            fader.FadeTo(loadToScene);
        }

        //3초뒤에 anykey 활성화, 10초 뒤에 씬 전환
        IEnumerator TitleProcess()
        {
            yield return new WaitForSeconds(3f);
            anykeyText.SetActive(true);
            isAnyKey=true;

            yield return new WaitForSeconds(7f);
            GotoMenu();
        }
    }
}