using UnityEngine;

namespace MySample
{
    public class SoundTest : MonoBehaviour
    {

        #region Variables
        private AudioSource audioSource;
        public AudioClip clip;              //재생할 오디오 클립

        [SerializeField] private float volume = 1.0f;       //볼륨
        [SerializeField] private float pitch = 1.0f;        //재생속도
        [SerializeField] private bool loop = false;         //반복여부
        //[SerializeField] private bool playOnAwake = false;  //시작시 바로 재생하는지 여부확인

        #endregion

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            SoundPlay();
        }

        void SoundPlay()
        {
            audioSource.clip = clip;
            audioSource.pitch = pitch;
            audioSource.loop = loop;
            audioSource.volume = volume;

            audioSource.Play();
        }

        void SoundOnShot()
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
