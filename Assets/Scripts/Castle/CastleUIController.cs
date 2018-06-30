using System.Collections;
using System.Collections.Generic;
using SupremumStudio;
using UnityEngine;
using UnityEngine.UI;

public class CastleUIController : MonoBehaviour
{
	private float _healthCastle = 100;
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

	private void OnTriggerEnter(Collider other)
	{
		print(1231231);
		HealthCastle -= other.GetComponent<Enemy>().Damage;
	}
}
