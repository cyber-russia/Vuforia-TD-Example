using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CyberRussia.ARTDImageTarget
{
    public class SpawnController : MonoBehaviour
    {
        public Spawn _Spawn;
        public EnemyController Enemy;
        public float Rate = 1;
        public PathBuilder _PathBuilder;
        public static int CurentEnemy;
        private static PoolObject _enemyPool;
       
        
        private void Start()
        {
            CurentEnemy = 0;
            GameManager.OnStartGame += StartWave;
        }

        private void Awake()
        {
            Enemy = _Spawn.EnemyPrefab.GetComponent<EnemyController>();
            Enemy.PathPoint = _PathBuilder;
            _enemyPool = new PoolObject(Enemy.gameObject, _Spawn.CountEnemy, transform.position, new GameObject("EnemyPool").transform);
            GameObject  _modelBuilding = Instantiate(_Spawn.ModelPrefab, transform.position,transform.rotation, transform);
            _modelBuilding.transform.SetParent(transform); 
        }


        private IEnumerator WaveEnemys()
        {
            for (int i = 0; i < _Spawn.CountEnemy; i++)
            {
                EnemyController enemy = _enemyPool.GetObjectFromPool().GetComponent<EnemyController>();
                enemy.transform.position = transform.position;
                enemy.Health = _Spawn.Health;
                enemy.speed = _Spawn.Speedenemy;
                enemy.Damage = _Spawn.Damage;
                CurentEnemy++;
                yield return new WaitForSeconds(Rate);
            }
        }

        void StartWave()
        {
            StartCoroutine(WaveEnemys());            
        }

        public static  bool CheckEndGame()
        {
            foreach (var item in _enemyPool.PoolObjects)
            {
                if(item.activeInHierarchy)
                    return false;
            }

            return true;
        }
    }
}
