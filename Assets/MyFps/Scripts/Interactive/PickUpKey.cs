using UnityEngine;

namespace MyFps
{
    public class PickUpKey : Interactive
    {
        #region Variables

        #endregion

        protected override void DoAction()
        {
            //key item 저장
            PlayerStats.Instance.AcquirePuzzleItem(PuzzleKey.ROOM01_KEY);

            //키를 얻으면 오브젝트 파괴
            Destroy(gameObject);
        }
    }
}
