using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.UI;

namespace CyberRussia.ARTDImageTarget
{
    public class CastleController : MonoBehaviour
    {
        public Castle _Castle;

        public Image _hpBar;
        public Text _hpText;
        
        private int _health;

        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;
                if(_health <= 0)
                    Dath();
                 UIController.HealthBar(_hpBar, _health,_hpText); 
            }
        }

        private void Awake()
        {
            GameObject _modelCastle = Instantiate(_Castle.CastleModel, transform.position, transform.rotation, transform);
            _modelCastle.name = "MainCastle";
            _hpBar = _modelCastle.GetComponentInChildren<Image>();
            _hpText = _modelCastle.GetComponentInChildren<Text>();
        }

        private void OnEnable()
        {
            _health = _Castle.HealthCastle;
        }
        
        void OnTriggerEnter (Collider other)
        {
            Health -= other.GetComponent<EnemyController >().Damage;
            other.gameObject.SetActive(false );
        }
        
        public void Dath()
        {
             GameManager.EndGame("Замок завоеван");  
        }
    }
}