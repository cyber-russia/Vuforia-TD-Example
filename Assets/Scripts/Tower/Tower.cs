using UnityEngine;

namespace SupremumStudio
{
    [CreateAssetMenu(fileName = "Tower", menuName = "SupremumStudio/Tower", order = 1)]
    public class Tower: ScriptableObject
    {
        [Header("Перенесите сюда модель башни")]
        public GameObject TowerModel;

        [Header("Перетащите сюда модель пули")]
        public GameObject Bullet;
        
        [Header("Укажите скорость стрельбы")]
        [Range(1,10)]
        public int ShooterSpeed;

        [Header("Укажите угол разброса выстрела пуль")]
        [Range(0,25)]
        public float SprayAngle;

        [Header("Укажите урон башни")]
        [Range(1,100)]
        public int Damage;
        
        
        
    }
}