using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawner", menuName = "SupremumStudio/Spawner", order = 0)]
public class Spawner : ScriptableObject
{

	[Header("Перенесите сюда модель сооружения")]
	public GameObject ModelPrefab;

	[Header("Перенесите сюда модель Enemy")]
	public GameObject EnemyPrefab;

	[Header("Укажите колличество Enemy")] [Range(1, 50)]
	public int CountEnemy;
	
	[Header("Укажите скорость перемещения Enemy")]
	[Range(1,25)]
	public float Speedenemy;

	[Header("Укажите частоту создания противника")]
	[Range(0,25)]
	public float RateInstantce;
	
	[Header("Укажите урон Замка")] 
	[Range(1,100)]
	public int Damage;


}
