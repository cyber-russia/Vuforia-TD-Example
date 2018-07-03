using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace SupremumStudio
{
    public delegate void DelegateManager();

    public class GameManager : MonoBehaviour
    {
        public static event DelegateManager ScaningComplete = () => { print("Scaning off"); };
        public static event DelegateManager StartGame = () => { print("startGame");};
        public Button StartGameButton;
        public Button Continuebutton;
        public GameObject UI_Panel_Scaner;
        public GameObject EndPanel;
        public Text endText;
        public static GameManager Instance;
        public PathBuilder PathBuilder;

        public List<Marker> Markers = new List<Marker>();

        public List<GameObject> ImageTarget = new List<GameObject>();

        //private bool _scanComplete = false;
        private bool isStartgame =false;
        public static bool End = false;

        void OnScanPanel()
		{
			UI_Panel_Scaner.SetActive(true);
		}
		
		void OffScanPanel()
		{
			UI_Panel_Scaner.SetActive(false);
		}
		
		void OnButtonStart()
		{
            if(!isStartgame)
                StartGameButton.gameObject.SetActive(true);
		}

        bool CheckScan()
        {
            var _m = Markers.Count;
            var _i = ImageTarget.Count;
            if (_m == _i)
            {
                //_scanComplete = true;
                ScaningComplete(); // закончилось сканирование всех меток.
                return true;
            }
            else
            {
                return false;
            }
        }

        bool CheckPath() //провереям есть ли среди меток спавн и башня. (минимальное количество для создания меток)
        {
            bool isCastle = false;
            bool isSpawn = false;
            foreach (var marker in Markers)
            {
                if (marker.TargetType == MarkerType.SPAWN)
                {
                    isSpawn = true;
                }

                if (marker.TargetType == MarkerType.CASTLE)
                {
                    isCastle = true;
                }
            }

            if (isSpawn && isCastle)
            {
                return true;
            }

            return false;
        }

        void AddMarker(Marker m)
        {
            if (!Markers.Contains(m))
            {
                Markers.Add(m);
            }

            //OnTimeScale();
             
                
            if (CheckAllMarker() && isStartgame)
                Continuebutton.gameObject.SetActive(true);    
        }   

        public void Continue()
        {
            OffScanPanel();
            Continuebutton.gameObject.SetActive(false);
            Time.timeScale = 1;
        }

        void LostMarker(Marker m)
        {
            if (Markers.Contains(m))
            {
                print("Lost");
                //_scanComplete = false;
                OnScanPanel();
                if(isStartgame)
                {
					Continuebutton.gameObject.SetActive(false);
					Time.timeScale = 0;
                }
                else
                {
                    StartGameButton.gameObject.SetActive(false);
                }
            }
        }

        bool CheckAllMarker()
        {
            foreach (var marker in Markers)
            {
                if (!marker.gameObject.activeInHierarchy)
                {
                    return false;
                }
            }

                CheckScan();
            return true;
        }

        void OnTimeScale()
        {
            if (CheckAllMarker())
            {
                Time.timeScale = 1;
            }
        }

        void Singleton()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                DestroyImmediate(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);
        }

        private void Awake()
        {
            Marker.EnableMark += AddMarker;
            Marker.DisableMark += LostMarker;
            StartGame += OffScanPanel;
            ScaningComplete += OnButtonStart;
            CastleUIController.OnEndGame += EndGame;
            
            Singleton();
            if (!PathBuilder)
            {
                Debug.Break();
            }

            CheckAllMarker();
        }

        public void StartGames()
        {
            StartGameButton.gameObject.SetActive(false);
            isStartgame = true;
            StartGame();
        }

        public void EndGame(string result)
        {
            endText.text = result;
            EndPanel.SetActive(true);
        }

        public void restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}