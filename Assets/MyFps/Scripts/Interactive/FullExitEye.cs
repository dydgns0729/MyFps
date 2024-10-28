using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace MyFps {
    public class FullExitEye :Interactive
    {
        #region Variables
        public TextMeshProUGUI textBox;
        [SerializeField] private string rightSequence = "You need the RightEye";
        [SerializeField] private string leftSequence = "You need the LeftEye";
        [SerializeField] private string allSequence = "You need the Left and Right Eye";

        public GameObject leftEye;
        public GameObject rightEye;

        public GameObject exitWall;
        public GameObject exitTrigger;
        #endregion

        IEnumerator NotEnoughPuzzle()
        {
            unInteractive = true;

            textBox.gameObject.SetActive(true);
            

            yield return new WaitForSeconds(2f);
            unInteractive = false;
            textBox.gameObject.SetActive(false);
            textBox.text = "";
        }


        protected override void DoAction()
        {
            if (!CheckPuzzle())
            {
                StartCoroutine(NotEnoughPuzzle());
            }
            else
            {
                StartCoroutine(OpenExitWall());
            }
        }

        IEnumerator OpenExitWall()
        {
            //출구를 열고 출구 콜라이더 제거
            exitWall.GetComponent<Animator>().SetBool("IsOpen",true);
            //exitWall.GetComponent<BoxCollider>().enabled = false;
            unInteractive = true;
            
            yield return new WaitForSeconds(0.5f);
            //exit 트리거 활성화

            exitTrigger.SetActive(true);
        }

        private bool CheckPuzzle()
        {
            bool hasLeftEye = PlayerStats.Instance.HasPuzzleItem(PuzzleKey.LEFTEYE_KEY);
            bool hasRightEye = PlayerStats.Instance.HasPuzzleItem(PuzzleKey.RIGHTEYE_KEY);

            if (!hasLeftEye && !hasRightEye)
            {
                textBox.text = allSequence;
                return false;
            }
            else if (!hasLeftEye && hasRightEye)
            {
                textBox.text = leftSequence;
                rightEye.SetActive(true);
                return false;
            }
            else if (hasLeftEye && !hasRightEye)
            {
                textBox.text = rightSequence;
                leftEye.SetActive(true);
                return false;
            }

            rightEye.SetActive(true);
            leftEye.SetActive(true);
            return true;
        }
    }
}