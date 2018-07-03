using UnityEngine;

namespace SupremumStudio.Castle
{
    public class CastleController:MonoBehaviour
    {
        public Castle Castle;

        private GameObject _modelCastle;

        void BuildingCastle()
        {
            _modelCastle = Instantiate(Castle.CastleModel, transform.position, transform.rotation, transform);
            _modelCastle.name = "MainCastle";
            _modelCastle.GetComponent<CastleUIController>().HealthCastle = Castle.HealthCastle;
        }

        private void Awake()
        {
            BuildingCastle();
        }
    }
}