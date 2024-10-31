using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace MyFps
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        [SerializeField] string loadtoScene = "MainScene01";
        public SceneFader fader;

        private AudioManager audioManager;

        //SetActive활성화/비활성화를 위한 GameObject
        public GameObject mainMenuUI;
        public GameObject optionUI;
        public GameObject creditUI;

        //Audio
        public AudioMixer audioMixer;
        public Slider bgmSlider;
        public Slider sfxSlider;
        #endregion

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private void Start()
        {
            LoadOptions();

            fader.FromFade();
            //참조
            audioManager = AudioManager.Instance;

            //BGM 플레이
            audioManager.PlayBGM("MenuBGM");
        }

        public void NewGame()
        {
            audioManager.Stop(audioManager.BgmSound);
            audioManager.Play("MenuButton");
            fader.FadeTo(loadtoScene);
        }

        public void LoadGame()
        {
            Debug.Log("Load Game");
        }

        public void Options()
        {
            audioManager.PlayBGM("PlayBGM");
            ShowOptions();
        }

        public void Credits()
        {
            ShowCredit();
            Debug.Log("Credits");
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }

        private void ShowOptions()
        {
            audioManager.Play("MenuButton");
            mainMenuUI.SetActive(false);
            optionUI.SetActive(true);
        }

        public void OptionExit()
        {
            //옵션창을 나갈때 값을 저장
            SaveOptions();

            optionUI.SetActive(false);
            mainMenuUI.SetActive(true);
        }

        //AudioMixer BGM -40~0 세팅
        public void SetBGMVolume(float value)
        {
            audioMixer.SetFloat("BgmVolume", value);
            Debug.Log(value);

        }

        //AudioMixer BGM -40~0 세팅
        public void SetSFXVolume(float value)
        {
            audioMixer.SetFloat("SfxVolume", value);
        }

        //옵션값 저장하기
        public void SaveOptions()
        {
            PlayerPrefs.SetFloat("BgmVolume",bgmSlider.value);
            PlayerPrefs.SetFloat("SfxVolume",sfxSlider.value);
        }

        //옵션값 로드하기
        private void LoadOptions()
        {
            float bgmVolume = PlayerPrefs.GetFloat("BgmVolume", 0);
            SetBGMVolume(bgmVolume);        //사운드 볼륨 조절
            bgmSlider.value = bgmVolume;    //UI 세팅

            float sfxVolume = PlayerPrefs.GetFloat("SfxVolume", 0);
            SetSFXVolume(sfxVolume);        //사운드 볼륨 조절
            sfxSlider.value = sfxVolume;    //UI 세팅
        }

        private void ShowCredit()
        {
            mainMenuUI.SetActive(false);
            creditUI.SetActive(true);
        }

    }
}