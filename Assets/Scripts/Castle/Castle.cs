using UnityEngine;

namespace SupremumStudio.Castle
{
    [CreateAssetMenu(fileName = "MainCastle", menuName = "SupremumStudio/MainCastle", order = 1)]
    public class Castle : ScriptableObject
    {
        [Header("Модель главного замка")] public GameObject CastleModel;

        [Header("Количество здоровья главного замка")]
        public int HealthCastle;
    }
}