using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SupremumStudio
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public PathBuilder PathBuilder;

        public List<Marker> Markers = new List<Marker>();

        public static bool Scan = true; //для вноса меток.


      

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
            OnTimeScale();
        }
        
        void LostMarker(Marker m)
        {
            if (Markers.Contains(m))
            {
                print("Lost");
                Time.timeScale = 0;
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

            Singleton();
            if (!PathBuilder)
            {
                Debug.Break();
            }

            CheckAllMarker();
        }
    }
}