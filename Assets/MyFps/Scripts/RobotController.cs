using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public enum RobotState
    {
        R_Idle,
        R_Walk,
        R_Attack,
        R_Death
    }

    public class RobotController : MonoBehaviour
    {
        #region Variables
        private Animator animator;

        //로봇 상태
        private RobotState currentState;
        //로봇 이전 상태
        private RobotState beforeState;

        //체력
        [SerializeField] private float health = 20f;

        #endregion

        private void Awake()
        {
            animator = GetComponent<Animator>();

            SetState(RobotState.R_Idle);
        }

        //로봇의 상태변경
        private void SetState(RobotState newState)
        {
            //현재 상태 체크
            if(currentState == newState) return;

            //이전 상태 저장
            beforeState = currentState;
            //상태변경
            currentState = newState;
            //상태변경에 따른 구현 내용
            animator.SetInteger("RobotState", (int)newState);
        }

    }
}