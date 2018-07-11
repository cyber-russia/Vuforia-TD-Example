using UnityEngine;

namespace CyberRussia.ARTDImageTarget
{
    [CreateAssetMenu(fileName = "MainCastle", menuName = "ARTDImageTarget/MainCastle", order = 1)]
    public class Castle : ScriptableObject 
    {
        [Header("Модель главного замка")] 
        public GameObject CastleModel;

        [Header("Количество здоровья главного замка")]
        public int HealthCastle;
    }
}