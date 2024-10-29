using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Unity.Burst.Intrinsics.X86;

namespace MyFps
{
    public enum EnemyState
    {
        E_Idle,     //대기
        E_Walk,     //걷기 - 적을 디텍팅하지 못한 경우
        E_Attack,   //스매시 공격
        E_Death,    //죽음
        E_Chase     //추격(걷기 상태) - 적을 디텍팅한 경우
    }

    public class Enemy : MonoBehaviour, IDamageable
    {
        #region Variables

        private Transform thePlayer;
        private Animator animator;
        private NavMeshAgent agent;

        //로봇 상태
        private EnemyState currentState;
        //로봇 이전 상태
        private EnemyState beforeState;

        //체력
        [SerializeField] private float maxHealth = 20f;
        private float currentHealth;

        private bool isDeath;

        //공격
        [SerializeField] private float attackRange = 1.5f;      //공격 가능 범위
        [SerializeField] private float attackDamage = 5f;       //공격력

        //패트롤
        public Transform[] wayPoints;
        private int nowWayPoint;

        private Vector3 startPosition;  //시작위치, 타겟을 잃어버렸을때 돌아갈 위치
        #endregion

        private void Awake()
        {
            //참조
            thePlayer = GameObject.Find("Player").transform;
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            //초기화
            isDeath = false;
            currentHealth = maxHealth;
            nowWayPoint = 0;
            startPosition = transform.position;
            if (wayPoints.Length > 0)
            {
                SetState(EnemyState.E_Walk);
                GoNextPoint();
            }
            else
            {
                SetState(EnemyState.E_Idle);
            }
        }

        private void Update()
        {

            if (isDeath) return;

            //방향 구하기(타겟 지정)
            Vector3 dir = thePlayer.transform.position - this.transform.position;
            float distance = Vector3.Distance(thePlayer.transform.position, transform.position);
            if (distance <= attackRange)
            {
                SetState(EnemyState.E_Attack);
            }

            switch (currentState)
            {
                case EnemyState.E_Idle:
                    break;

                case EnemyState.E_Walk:
                    //도착판정
                    if (agent.remainingDistance <= 0.2f)
                    {
                        if (wayPoints.Length > 0)
                        {
                            GoNextPoint();
                        }
                        else
                        {
                            SetState(EnemyState.E_Idle);
                        }
                    }
                    break;

                case EnemyState.E_Attack:
                    transform.LookAt(thePlayer.position);
                    if (distance > attackRange)
                    {
                        SetState(EnemyState.E_Chase);
                    }
                    break;

                case EnemyState.E_Chase:
                    //플레이어 위치 업데이트
                    agent.SetDestination(thePlayer.position);
                    break;
            }
        }

        private void Attack()
        {
            IDamageable damageable = thePlayer.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(attackDamage);
            }
        }

        //적의 상태변경
        public void SetState(EnemyState newState)
        {
            //현재 상태 체크
            if (currentState == newState) return;

            //이전 상태 저장
            beforeState = currentState;
            //상태변경
            currentState = newState;
            //상태변경에 따른 구현 내용
            if (currentState == EnemyState.E_Chase)
            {
                animator.SetInteger("EnemyState", 1);
                animator.SetLayerWeight(1, 1f);
            }
            else
            {
                animator.SetInteger("EnemyState", (int)newState);
                animator.SetLayerWeight(1, 0f);
            }
            agent.ResetPath();
        }

        public void TakeDamage(float damage)
        {

            currentHealth -= damage;
            //Debug.Log(currentHealth);

            if (currentHealth <= 0 && !isDeath)
            {
                Die();
            }
        }

        private void Die()
        {
            isDeath = true;

            Debug.Log("Robot Death");
            SetState(EnemyState.E_Death);

            //죽었을때 충돌체 제거
            transform.GetComponent<BoxCollider>().enabled = false;
        }

        //다음 웨이포인트로 이동
        private void GoNextPoint()
        {
            nowWayPoint++;
            if (nowWayPoint >= wayPoints.Length)
            {
                nowWayPoint = 0;
            }
            agent.SetDestination(wayPoints[nowWayPoint].position);
        }

    }
}