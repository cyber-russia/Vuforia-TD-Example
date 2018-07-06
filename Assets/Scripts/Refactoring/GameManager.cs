using UnityEngine;

namespace Refactoring
{
    public class GameManager : MonoBehaviour
    {
        private TrackerManager _tm;


        private void Awake()
        {
            print(this.name);
            _tm = new TrackerManager(); // обязательно инициализировать тут. \
        }

        void Start()
        {
            print(_tm);
        }

        
        
        public void SetStartGame()
        {
            _tm.CompleteScan = true;
        }

        public void ContinueGame()
        {
            _tm.OnTimeScale();
        }
    }
}