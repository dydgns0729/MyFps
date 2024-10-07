using TMPro;
using UnityEngine;

namespace MyFps
{
    public class DoorCellOpen : MonoBehaviour
    {
        #region Variables
        public GameObject actionUI;
        public TextMeshProUGUI actionTextUI;

        //Action
        private Animator animator;
        private Collider collider;
        public AudioSource audioSource;

        [SerializeField] private string action= "Open The Door";
        private float theDistance;

        #endregion

        private void Awake()
        {
            animator = GetComponent<Animator>();
            collider = GetComponent<BoxCollider>();
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
                actionTextUI.text = action;
                actionUI.SetActive(true);
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
            actionUI.SetActive(false);
        }

        void OpenDoor()
        {
            animator.SetBool("IsOpen", true);
            collider.enabled = false;
        }

        void HideActionUI()
        {
            actionUI.SetActive(false);
            actionTextUI.text = "";
        }
    }
}