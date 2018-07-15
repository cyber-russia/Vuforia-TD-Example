using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CyberRussia.ARTDImageTarget
{
    
    public delegate void OnAction();
    
    public class GameManager : MonoBehaviour
    {
        public static event OnAction OnStartGame;
        
        public List<Marker> Markers;
        public static bool isStart = false;
        public static bool End = false;
        public static UIController uiController;
    
        
        private void Awake()
        {
            AddMarker();
            Marker.OnEnableMarker += TrackedMarker;
            Marker.OnDisableMarker += LostMarker;
            uiController = GetComponent<UIController>();
        }

        
        void AddMarker()
        {
            Markers = Resources.FindObjectsOfTypeAll<Marker>().ToList();
        }

        public bool CheckAllScan()
        {
            
            foreach (var item in Markers)
            {
                if (!item.gameObject.activeInHierarchy)
                    return false;
            }
            return true;
        }

        void TrackedMarker(Marker m)  //TODO: Входящий параметр оказался не нужен 
        {
            if(CheckAllScan() && !isStart)
                uiController.EnableStartOrContinue(false);
            if(CheckAllScan() && isStart)
                uiController.EnableStartOrContinue(true);    
                
        }

        void LostMarker(Marker m)
        {
            if(End) return;
            Time.timeScale = 0;
            uiController.EnablePanelScaner(); 
            if(!isStart)
                uiController.DisableStartorContinue(false);
            else
                uiController.DisableStartorContinue(true); 
            
        }

        public void StartGame()
        {
            Time.timeScale = 1;
            if (OnStartGame != null) OnStartGame();
            uiController.OnStartGameButton();
        }

        public void ContinueGame()
        {
            uiController.OnContinueButton();
            Time.timeScale = 1;
        }

        public static void EndGame(string textResult)
        {
            End = true;
            uiController.endText.text =textResult;
            uiController.OnEnd();
            Time.timeScale = 0;
        }

        public void Restart()
        {
            End = false;
            isStart = false;
            SceneManager.LoadScene(0);
        }

        private void OnDestroy()
        {
            Marker.OnEnableMarker -= TrackedMarker;
            Marker.OnDisableMarker -= LostMarker;
        }
    }
}