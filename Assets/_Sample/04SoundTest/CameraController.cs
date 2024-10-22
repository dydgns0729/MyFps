using UnityEngine;

namespace MySample
{
    public class CameraController : MonoBehaviour
    {
        #region Variables
        public Transform thePlayer;
        [SerializeField] private Vector3 offset = Vector3.zero;
        #endregion

        private void LateUpdate()
        {
            this.transform.position = thePlayer.position + offset;

        }
    }
}