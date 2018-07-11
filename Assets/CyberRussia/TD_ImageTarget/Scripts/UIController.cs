using UnityEngine;
using UnityEngine.UI;

namespace CyberRussia.ARTDImageTarget
{
    public class UIController : MonoBehaviour
    {
        public GameObject StartGameButton;
        public GameObject ContinueButton;
        public GameObject UI_Panel_Scaner;
        public GameObject EndPanel;
        public Text endText;

        public void EnableStartOrContinue(bool isStart)
        {
            if(!isStart)
                StartGameButton.SetActive(true);
            else
                ContinueButton.SetActive(true);
        }
        
        public void DisableStartorContinue(bool isStart)
        {
            if(!StartGameButton || !ContinueButton) return;
                
            if(!isStart)
                StartGameButton.SetActive(false);
            else
                ContinueButton.SetActive(false);
        }
        

        public void OnStartGameButton()
        {
            GameManager.isStart = true;
            UI_Panel_Scaner.SetActive(false);
            StartGameButton.SetActive(false);
        }

        public void OnContinueButton()
        {
            UI_Panel_Scaner.SetActive(false);
            ContinueButton.SetActive(false);
            Time.timeScale = 1;
        }

        public void EnablePanelScaner()
        {
            if(UI_Panel_Scaner != null)
            UI_Panel_Scaner.SetActive(true);
        }

        public void OnEnd()
        {
            EndPanel.SetActive(true);
        }

        public static void HealthBar(Image slider, float health, Text text)
        {
            if (slider != null && text != null)
            {
                slider.color = Color.Lerp(Color.red, Color.green, health / 100);
                text.text = health.ToString();
                slider.fillAmount = health / 100;    
            }
        }
    }
}