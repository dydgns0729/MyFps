using UnityEngine;

namespace MyFps
{
    //퍼즐 아이템 획득 여부
    public enum PuzzleKey
    {
        ROOM01_KEY,
        MAX_KEY             //퍼즐 아이템 개수
    }
    //플레이어의 속성이나 데이터값을 관리하는 싱글톤(SingleTon)[DontDestroy]클래스 ammoCount
    public class PlayerStats : PersistentSingleton<PlayerStats>
    {
        #region Variables
        //탄환 갯수
        [SerializeField] private int ammoCount;

        public int AmmoCount
        {
            get { return ammoCount; }
            private set { ammoCount = value; }
        }


        //게임 퍼즐 아이템 키
        [SerializeField] private bool[] puzzlekeys;
        #endregion

        private void Start()
        {
            //속성값/Data값 초기화
            AmmoCount = 0;
            puzzlekeys = new bool[(int)PuzzleKey.MAX_KEY];
        }

        public void AddAmmo(int amount)
        {
            AmmoCount += amount;
        }

        public bool UseAmmo(int amount)
        {
            //소지 갯수 체크
            if (AmmoCount < amount)
            {
                Debug.Log("You need to ReLoad!");
                return false;   //사용량보다 부족할때
            }
            AmmoCount -= amount;
            return true;
        }

        //퍼즐 아이템 획득
        public void AcquirePuzzleItem(PuzzleKey key)
        {
            puzzlekeys[(int)key] = true;
        }

        //퍼즐 아이템 소지 체크
        public bool HasPuzzleItem(PuzzleKey key)
        {
            return puzzlekeys[(int)key];
        }
    }
}