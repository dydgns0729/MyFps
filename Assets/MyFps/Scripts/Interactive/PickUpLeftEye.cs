using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;


namespace MyFps
{
    public class PickUpLeftEye : Interactive
    {
        #region Variables
        //퍼즐 UI
        public GameObject puzzleUI;
        public Image itemImage;
        public TextMeshProUGUI itemText;

        public GameObject puzzleItemGp;

        public Sprite itemSprite;                           //획득한 아이템 아이콘 이미지
        [SerializeField] string puzzleStr = "Puzzle Text";  //획득한 아이템 안내문구
        #endregion

        protected override void DoAction()
        {
            StartCoroutine(GainPuzzleItem());
        }

        IEnumerator GainPuzzleItem()
        {
            //key item 저장
            PlayerStats.Instance.AcquirePuzzleItem(PuzzleKey.LEFTEYE_KEY);

            

            //UI 연출
            if (puzzleUI != null)
            {
                //아이템 트리거 비활성화
                puzzleItemGp.SetActive(false);
                this.GetComponent<BoxCollider>().enabled = false;

                itemImage.sprite = itemSprite;
                itemText.text = puzzleStr;
                puzzleUI.SetActive(true);

                yield return new WaitForSeconds(2f);

                puzzleUI.SetActive(false);

            }

            //키를 얻으면 오브젝트 파괴
            Destroy(gameObject);
        }

    }
}