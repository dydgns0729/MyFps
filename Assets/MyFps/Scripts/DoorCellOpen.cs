using TMPro;
using UnityEngine;

namespace MyFps
{
    public class DoorCellOpen : MonoBehaviour
    {
        #region Variables
        //ActionUI
        public GameObject actionUI;
        public TextMeshProUGUI actionTextUI;
        public GameObject extraCross;
        [SerializeField] private string action = "Open The Door";

        //Action
        private Animator animator;
        private Collider m_Collider;
        public AudioSource audioSource;

        private float theDistance;

        #endregion

        private void Awake()
        {
            animator = GetComponent<Animator>();
            m_Collider = GetComponent<BoxCollider>();
        }

        private void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
        }
        //마우스를 올려놓으면 ActionUI 활성화
        private void OnMouseOver()
        {
            if (theDistance <= 2f)
            {
                ShowActionUI();
                if (Input.GetButtonDown("Action"))
                {
                    OpenDoor();
                    HideActionUI();
                    audioSource.Play();
                }
            }
            else
            {
                HideActionUI();
            }
        }

        //마우스가 벗어나면 액션 UI를 숨긴다
        private void OnMouseExit()
        {
            HideActionUI();
        }

        void OpenDoor()
        {
            animator.SetBool("IsOpen", true);
            m_Collider.enabled = false;
        }

        void HideActionUI()
        {
            actionUI.SetActive(false);
            actionTextUI.text = "";
            extraCross.SetActive(false);
        }

        void ShowActionUI()
        {
            actionTextUI.text = action;
            actionUI.SetActive(true);
            extraCross.SetActive(true);
        }
    }
}