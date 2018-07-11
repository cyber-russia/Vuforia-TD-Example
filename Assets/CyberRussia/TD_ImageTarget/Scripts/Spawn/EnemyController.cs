
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CyberRussia.ARTDImageTarget
{
    public class EnemyController: MonoBehaviour
    {
        public PathBuilder PathPoint;
        public float speed = 1;
        private int index;
        public int Damage;
        private int _health;
        public Image _hpBar;
        public Text _hpText;
        
        public int Health
        {
            get { return _health;}
            set
            {
                _health = value;
                if (_health <= 0)
                    Dath();
                UIController.HealthBar(_hpBar, _health,_hpText); 
            }
        }

        private void Update()
        {
            if (index < PathPoint.path.Count)
            {
                MoveToPath(PathPoint.path[index]);
            }
            else
            {
                index = 0;
                gameObject.SetActive(false);
            }
        }

        private void Awake()
        {
            _hpBar = GetComponentInChildren<Image>();
            _hpText = GetComponentInChildren<Text>();
        }

        private void OnEnable()
        {
          
        }

        private void MoveToPath(Vector3 position)
        {
            if (transform.position != position)
            {
                transform.LookAt(position); //это работает только с правильно подобранными моделями. В альтернативе надо поворачивать только по одной оси.

                transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);
            }
            else
            {
                index++; 
            }    
        }

        void Dath()
        {           
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            index = 0;
            if(SpawnController.CheckEndGame() && GameManager.isStart)
                GameManager.EndGame("Замок не завоеван");
        }
    }
}