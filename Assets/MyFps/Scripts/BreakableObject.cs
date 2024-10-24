using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class BreakableObject : MonoBehaviour, IDamageable
    {
        #region Variables
        [SerializeField] string breakSound = "PotterySmash";
        public GameObject fakeObject;
        public GameObject breakObject;
        public GameObject effectObject;
        public GameObject hiddenItem;

        private bool isBreak;
        [SerializeField] private bool unBreakable = false;                               //true : 깨지지 않는 오브젝트라는 뜻
        #endregion

        private void Start()
        {
            isBreak = false;
        }

        //총을 맞으면

        public void TakeDamage(float damage)
        {
            if (unBreakable) return;

            if (!isBreak)
            {
                //BreakObject();
                StartCoroutine(BreakObject());
            }
        }

        //public void BreakObject()
        //{
        //    isBreak = true;

        //    this.GetComponent<BoxCollider>().enabled = false;
        //    fakeObject.SetActive(false);

        //    breakObject.SetActive(true);
        //    AudioManager.Instance.Play(breakSound);
        //}

        ////Fake -> Break, 깨지는 사운드 재생
        IEnumerator BreakObject()
        {
            isBreak = true;

            this.GetComponent<BoxCollider>().enabled = false;
            fakeObject.SetActive(false);

            yield return new WaitForSeconds(0.1f);

            AudioManager.Instance.Play(breakSound);
            breakObject.SetActive(true);
            if (effectObject != null)
            {
                effectObject.SetActive(true);

                yield return new WaitForSeconds(0.05f);
                effectObject.SetActive(false);
            }
            if (hiddenItem != null)
            {
                hiddenItem.SetActive(true);
            }
        }
    }
}