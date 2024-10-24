using TMPro;
using System.Collections;
using UnityEngine;

namespace MyFps
{
    public class DoorKeyOpen : Interactive
    {
        #region Variables
        public TextMeshProUGUI textBox;
        [SerializeField] private string sequence = "You need the Key";
        #endregion
        protected override void DoAction()
        {
            //문열기
            if (PlayerStats.Instance.HasPuzzleItem(PuzzleKey.ROOM01_KEY))
            {
                OpenDoor();
            }
            else
            {
                StartCoroutine(LockedDoor());
            }
        }

        private IEnumerator LockedDoor()
        {
            AudioManager.Instance.Play("DoorLocked");
            unInteractive = true;
            //this.GetComponent<BoxCollider>().enabled = false;

            textBox.gameObject.SetActive(true);
            textBox.text = sequence;
            
            yield return new WaitForSeconds(2f);
            unInteractive = false;
            //this.GetComponent<BoxCollider>().enabled = true;
            textBox.gameObject.SetActive(false);
            textBox.text = "";
        }

        //문열기
        void OpenDoor()
        {
            this.GetComponent<Animator>().SetBool("IsOpen", true);
            AudioManager.Instance.Play("DoorOpen");
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}