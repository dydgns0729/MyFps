using TMPro;
using UnityEngine;

namespace MyFps
{
    public class PickUpPistol : Interactive
    {
        #region Variables
        //Action
        public GameObject realPistol;
        public GameObject arrow;
        #endregion

        protected override void DoAction()
        {
            //픽업시 화살표 비활성화, 피스톨 활성화, 트리거 비활성화를 위한 Destroy
            realPistol.SetActive(true);
            arrow.SetActive(false);
            Destroy(gameObject);
        }
    }
}