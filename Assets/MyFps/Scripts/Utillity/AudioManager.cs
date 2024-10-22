using UnityEngine;

namespace MyFps
{
    //오디오를 관리하는 클래스
    public class AudioManager : PersistentSingleton<AudioManager>
    {
        #region Variables
        public Sound[] sounds;

        private string bgmSound = "";       //현재 플레이 되는 배경음 이름 확인용 
        public string BgmSound
        {

            get { return bgmSound; }
        }

        #endregion

        protected override void Awake()
        {
            //Singleton 구현부
            base.Awake();

            //AudioManager 초기화
            foreach (var sound in sounds)
            {
                sound.source = this.gameObject.AddComponent<AudioSource>();

                sound.source.clip = sound.clip;
                sound.source.volume = sound.volume;
                sound.source.pitch = sound.pitch;
                sound.source.loop = sound.loop;
            }
        }

        public void Play(string name)
        {
            Sound sound = null;

            //매개변수의 이름과 같은 클립 찾기
            foreach (var s in sounds)
            {
                if (s.clipName == name)
                {
                    sound = s;
                    break;
                }
            }

            //매개변수 이름과 같은 클립이 없으면
            if (sound == null)
            {
                Debug.Log($"Cannot Find {name}");
                return;
            }

            sound.source.Play();
        }

        public void Stop(string name)
        {
            Sound sound = null;

            //매개변수의 이름과 같은 클립 찾기
            foreach (var s in sounds)
            {
                if (s.clipName == name)
                {
                    sound = s;

                    //
                    if (s.clipName == bgmSound)
                    {
                        bgmSound = "";
                    }
                    break;
                }
            }

            //매개변수 이름과 같은 클립이 없으면
            if (sound == null)
            {
                Debug.Log($"Cannot Find {name}");
                return;
            }
            else
            {
                Debug.Log($"{name} stop");
            }

            sound.source.Stop();
        }

        //배경음 재생
        public void PlayBGM(string name)
        {
            //배경음 이름 체크
            if (bgmSound == name)
            {
                return;
            }

            //기존에 재생되던 BGM 정지
            Stop(bgmSound);

            Sound sound = null;

            foreach (var s in sounds)
            {
                if (s.clipName == name)
                {
                    bgmSound = s.clipName;
                    sound = s;
                    break;
                }
            }

            if (sound == null)
            {
                Debug.Log($"Cannot Find {name}");
                return;
            }

            sound.source.Play();
        }
    }
}