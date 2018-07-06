using System.Collections.Generic;
using UnityEngine;

namespace Refactoring
{
    /// <summary>
    /// Наблюдатель за метками
    /// </summary>
    public delegate void DelegateTrackerManager();

    public class TrackerManager
    {
        public TrackerManager()
        {
            CallPauseGame += OffTimeScale;
            
            ImageTarget.RegistrImageTarget += AddImageTarget;

            TargetContent.ContentOn += AddTargetContent;
            TargetContent.ContentOff += DisableTargetContent;

        }

        public static DelegateTrackerManager CallInitGame;
        public static DelegateTrackerManager CallPauseGame;
        public static DelegateTrackerManager CallContinueGame;
        public static DelegateTrackerManager CallLostMarkerBeforeGame;

        private List<ImageTarget> _targets = new List<ImageTarget>();
        private List<TargetContent> _contents = new List<TargetContent>();

        private bool _completeScan = false;

        public bool CompleteScan
        {
            get { return _completeScan; }
            set { _completeScan = value; }
        }


        public void OnTimeScale()
        {
            Time.timeScale = 1;
        }

        void OffTimeScale()
        {
            Time.timeScale = 0;
        }


        /// <summary>
        /// Регистрация всего Контента
        /// </summary>
        /// <param name="content"></param>
        void AddTargetContent(TargetContent content)
        {
            //Проверка на наличие в массиве
            if (!_contents.Contains(content))
            {
                _contents.Add(content);
            }

//            Debug.Log(!_completeScan + "----" + _targets.Count + "---" + _contents.Count);
            
            //проверка начального сканирования и соотвествия меток контенту
            if (!_completeScan && InitGame())
            {
//                Debug.Log("Begin GAme");
                if (CallInitGame != null)
                {
                    CallInitGame();
                    return;
                }
            }


            //Если игра идет и потерялаь метка
            if (_completeScan && !ActiveConents())
            {
                if (CallLostMarkerBeforeGame != null)
                {
                    CallLostMarkerBeforeGame();
                    return;
                }
            }

            //Если пауза, проверяем метки
            if (_completeScan && TargetAndContentEquals())
            {
                Debug.Log("93 line =>"+ ActiveConents()+"=>" + TargetAndContentEquals() );
                if (CallContinueGame != null)
                {
                    CallContinueGame();
                    return;
                }
            }
        }

        /// <summary>
        /// Регистрация ImageTarget
        /// </summary>
        /// <param name="imageTarget"></param>
        void AddImageTarget(ImageTarget imageTarget)
        {
            if (!_targets.Contains(imageTarget))
            {
                _targets.Add(imageTarget);
            }
        }

        void DisableTargetContent(TargetContent content)
        {
            if (_contents.Contains(content))
            {
                _contents.Remove(content);
            }

            if (_completeScan && CallPauseGame != null)
            {
                CallPauseGame();
            }

            if (!_completeScan)
            {
                if (CallLostMarkerBeforeGame!= null)
                {
                CallLostMarkerBeforeGame();
                }
            }
        }

        /// <summary>
        /// Проверка активности контента
        /// </summary>
        /// <returns></returns>
        bool ActiveConents()
        {
            foreach (var c in _contents)
            {
                if (!c.gameObject.activeInHierarchy)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Сверяет, все ли зарегистрировался весь контент с ImageTargets
        /// </summary>
        /// <returns></returns>
        bool TargetAndContentEquals()
        {
            return _targets.Count == _contents.Count;
        }

        bool InitGame()
        {
            return ActiveConents() && TargetAndContentEquals();
        }

        bool ContinueGame() //TODO: бесполезное гавно
        {
            return ActiveConents();
        }


        
        
        
        //Delete
        public override string ToString()
        {
            string CountTarget = _targets.Count.ToString();
            string CountContent = _contents.Count.ToString();

            return CountTarget+" - "+ CountContent;
        }
    }
}