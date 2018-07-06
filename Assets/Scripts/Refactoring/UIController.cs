using UnityEngine;

namespace Refactoring
{
    public class UIController : MonoBehaviour
    {
        public GameObject StartButton;
        public GameObject ContinueButton;
        public GameObject PanelScan;


        private void Awake()
        {
            TrackerManager.CallInitGame += () =>
            {
                if (StartButton != null)
                {
                    StartButton.SetActive(true);
                }
            };

            TrackerManager.CallPauseGame += () =>
            {
                if (PanelScan != null)
                {
                    PanelScan.SetActive(true);
                }
            };

            TrackerManager.CallLostMarkerBeforeGame += () =>
            {
                if (StartButton != null)
                {
                    StartButton.SetActive(false);
                }
            };

            TrackerManager.CallContinueGame += () =>
            {
                if (ContinueButton != null)
                {
                    ContinueButton.SetActive(true);
                }
            };

            StartButton.SetActive(false);
            ContinueButton.SetActive(false);
            PanelScan.SetActive(false);
        }
    }
}