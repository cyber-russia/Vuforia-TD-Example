using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Refactoring
{
    public class _deleeteMe_PoolTest: MonoBehaviour
    {
        private PoolObject<EnemyController> Enemys;
        public int CountPool =10;
        public GameObject _Prefabs;
        public List<Vector3> road;
        
        
        private void Awake()
        {
            Enemys = new PoolObject<EnemyController>(_Prefabs, 10, new GameObject("Enemy").transform);
        }

        private void Start()
        {
            StartCoroutine(Fire());

        }

        IEnumerator Fire()
        {
            for (int i = 0; i < 5; i++)
            {
                Enemys.GetPoolObject().SettingsEnemy(road, Vector3.zero, 5);
                yield return new WaitForSeconds(2);
            }
        }
    }
}