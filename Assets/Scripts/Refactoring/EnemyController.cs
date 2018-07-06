using System.Collections.Generic;
using UnityEngine;

namespace Refactoring
{
    public class EnemyController: MonoBehaviour
    {
        
        public void SettingsEnemy(List<Vector3> road, Vector3 startPosition, float Speed)
        {
            _road = road;
            _startPosition = startPosition;
            _speed = Speed;
        }
        
        private List<Vector3> _road  = new List<Vector3>();
        private Vector3 _startPosition = new Vector3();
        private int _numberWayPoint = 0;
        
        
        public int NumberWayPoint
        {
            get { return _numberWayPoint; }
            set
            {
                if (value>_road.Count)
                {
                    return;
                }
                _numberWayPoint = value;
            }
        }

        private float _speed;

       

        private void OnEnable()
        {
            transform.position = _startPosition;
        }


        private void Update()
        {
//            print("Number -" + NumberWayPoint);
//            print("Road -" + _road.Count);
            if (NumberWayPoint<_road.Count)
            {
                Move(_road[NumberWayPoint]);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        void Move(Vector3 target)
        {
            if (transform.position != target)
            {
//                transform.LookAt(target); //это работает только с правильно подобранными моделями. В альтернативе надо поворачивать только по одной оси.
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * _speed);
            }
            else
            {
                NumberWayPoint++;
            }
        }

        private void OnDisable()
        {
            transform.position = _startPosition;
            NumberWayPoint = 0;
        }
    }
}