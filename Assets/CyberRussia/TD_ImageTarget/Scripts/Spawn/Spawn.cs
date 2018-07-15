using UnityEngine;

namespace CyberRussia.ARTDImageTarget
{
    [CreateAssetMenu(fileName = "Spawner", menuName = "ARTDImageTarget/Spawner", order = 0)]
    public class Spawn : ScriptableObject
    {
        [Header("Перенесите сюда модель сооружения")]
        public GameObject ModelPrefab;

        [Header("Перенесите сюда модель Enemy")]
        public GameObject EnemyPrefab;
        
        [Header("Укажите колличество Enemy")] [Range(1, 50)]
        public int CountEnemy;
	
        [Header("Укажите Колличество жизни Enemy")]
        [Range(0,100)]
        public int Health;
        
        [Header("Укажите скорость перемещения Enemy")]
        [Range(0,25)]
        public float Speedenemy;

        [Header("Укажите частоту создания противника")]
        [Range(0,25)]
        public float RateInstantce;
	
        [Header("Укажите урон Замка")] 
        [Range(1,100)]
        public int Damage;
    }
}