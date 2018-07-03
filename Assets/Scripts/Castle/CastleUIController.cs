using System.Collections;
using System.Collections.Generic;
using SupremumStudio;
using UnityEngine;
using UnityEngine.UI;




public class CastleUIController : MonoBehaviour
{
	public delegate void Death(string result);
    public static event Death OnEndGame;

    public static void CallOnEndGame(string result) {
        if (OnEndGame != null)
            OnEndGame(result);
        
    } 


	private float _healthCastle;
	public Image Background;
	public Text UIHealth;
	public float HealthCastle
	{
		get { return _healthCastle; }
		set
		{
			_healthCastle = value;
			Background.color = Color.Lerp(Color.red, Color.green, _healthCastle / 100);
			UIHealth.text = _healthCastle.ToString();
			Background.fillAmount = _healthCastle / 100;
		}
	}

	private void Awake()
	{
        HealthCastle = 100;
	}

	private void OnTriggerEnter(Collider other)
	{
        //print(1231231);
        var enemy = other.GetComponent<Enemy>();
		HealthCastle -= enemy.Damage;
        enemy.gameObject.SetActive(false);
        if (HealthCastle <= 0) 
        {
			OnEndGame("Башня завоевана");
        }
        else if (SpawnController.Curent == enemy.CountEnemy) 
        {
            foreach (var item in SpawnController.EnemyPool.PoolObjects)
            {
                if (item.activeSelf) return;
            }
            OnEndGame("Башня не завоевана");                 
        }
    }
}
