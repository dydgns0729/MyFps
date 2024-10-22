using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class MoveTest : MonoBehaviour
    {
        #region Variables
        Rigidbody rb;

        [SerializeField] float forwardForce = 5f;   //앞으로 가는 힘
        [SerializeField] float sideForce = 5f;      //좌우로 가는 힘

        private float dx;                           //좌우 입력값
        #endregion
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            dx = Input.GetAxis("Horizontal");

        }

        private void FixedUpdate()
        {
            //앞으로 이동
            rb.AddForce(0f, 0f, forwardForce, ForceMode.Acceleration);
            if (dx < 0f)
            {
                rb.AddForce(-sideForce, 0f, 0f, ForceMode.Acceleration);
            }
            if (dx > 0f)
            {
                rb.AddForce(sideForce, 0f, 0f, ForceMode.Acceleration);
            }

        }
    }
}