using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class Intro : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainScene01";

        //0.1
        public CinemachineDollyCart cart;

        private bool[] isArrive;
        [SerializeField] private int wayPointIndex = 0;     //이동 목표지점 인덱스

        //연출
        public Animator cameraAnim;
        public GameObject introUI;
        public GameObject theShedLight;
        #endregion

        private void Start()
        {
            //초기화
            cart.m_Speed = 0f;
            isArrive = new bool[5];
            wayPointIndex = 0;

            //

            StartCoroutine(StartIntro());
        }

        private void Update()
        {
            //도착판정
            if (cart.m_Position >= wayPointIndex && isArrive[wayPointIndex] == false)
            {
                //연출 - 마지막 지점인지 확인
                if (wayPointIndex == isArrive.Length - 1)
                {
                    //마지막지점
                    StartCoroutine(EndIntro());
                }
                else
                {
                    StartCoroutine(StayIntro());
                }
            }
            //인트로중 esc키를 누르면 스킵
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GoToMainScene();
            }
        }

        IEnumerator StartIntro()
        {
            isArrive[wayPointIndex] = true;
            wayPointIndex++;
            fader.FromFade();
            AudioManager.Instance.PlayBGM("IntroBGM");
            yield return new WaitForSeconds(1f);

            //카메라 애니메이션
            cameraAnim.SetTrigger("AroundTrigger");

            yield return new WaitForSeconds(2f);
            //출발
            cart.m_Speed = 0.1f;

        }

        IEnumerator StayIntro()
        {
            isArrive[wayPointIndex] = true;
            wayPointIndex++;

            cart.m_Speed = 0f;
            yield return new WaitForSeconds(1f);
            //카메라 애니메이션
            cameraAnim.SetTrigger("AroundTrigger");

            int nowIndex = wayPointIndex - 1;       //현재 위치의 웨이포인트 인덱스
            switch (nowIndex)
            {
                case 1:
                    introUI.SetActive(true);
                    break;
                case 2:
                    introUI.SetActive(false);
                    break;
                case 3:
                    theShedLight.SetActive(true);
                    break;
            }

            yield return new WaitForSeconds(2f);
            //출발
            cart.m_Speed = 0.1f;
        }

        //
        IEnumerator EndIntro()
        {
            isArrive[wayPointIndex] = true;
            cart.m_Speed = 0f;
            yield return new WaitForSeconds(2f);
            theShedLight.SetActive(false);
            yield return new WaitForSeconds(2f);
            GoToMainScene();
        }

        private void GoToMainScene()
        {
            fader.FadeTo(loadToScene);
            AudioManager.Instance.StopBGM();
        }
    }
}