using System.Collections.Generic;
using UnityEngine;

namespace SupremumStudio
{
	public class Enemy : MonoBehaviour
	{
		[SerializeField]
		public int _health;
		private int _countWayPoint;
		private List<Vector3> _ways;
		private Vector3 _startPosition;
		private int curentCountWayPoint;

		public float Speed=1;
        public int CountEnemy;

		public int Damage = 10;
		
		public int Health //пока не важно
		{
			get { return _health; }
			set
			{
			
				if (value <= 0)
				{
					gameObject.SetActive(false);
					return;
				}

				_health = value;

			}
		}

		private void Update()
		{
			if (_countWayPoint < _ways.Count)
			{
				Move(_ways[_countWayPoint]);
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
				transform.LookAt(target); //это работает только с правильно подобранными моделями. В альтернативе надо поворачивать только по одной оси.
				transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * Speed);
			}
			else
			{
				_countWayPoint++;
			}
		}

		private void OnEnable()
		{
			Health = 100;
			_startPosition = transform.position;
			_ways = GameManager.Instance.PathBuilder.Path;
		}

		private void OnDisable()
        {              
			///////////// Дописать логику проигрыша
            if (SpawnController.Curent == CountEnemy && GameManager.Instance.isStartgame)
            {
	            print(SpawnController.EnemyPool.PoolObjects);
                foreach (var item in SpawnController.EnemyPool.PoolObjects)
                {
                    if (item.activeSelf) return;
                }
                CastleUIController.CallOnEndGame("Башня не завоевана Из OnDisaibleEnemy");
            }
			transform.position = _startPosition;
		_countWayPoint = 0; // TODO: ПОчему заблочена? 
		}
	}
}