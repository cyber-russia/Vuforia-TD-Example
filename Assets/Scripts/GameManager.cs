using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SupremumStudio
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public PathBuilder PathBuilder;
        
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
            Singleton();
            if (!PathBuilder)
            {
                Debug.Break();
            }
        }
    }
}