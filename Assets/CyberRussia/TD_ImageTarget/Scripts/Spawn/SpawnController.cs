using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

namespace CyberRussia.ARTDImageTarget
{
    public class SpawnController : MonoBehaviour
    {
        public Spawn _Spawn;
        public EnemyController Enemy;
        public float Rate = 1;
        public PathBuilder _PathBuilder;
        public static int CountEnemy;
        public static int CurentEnemy;
        private static PoolObject _enemyPool;
        private Coroutine waveCoroutine;
        private void Start()
        {
            CurentEnemy = 0;
            GameManager.OnStartGame += StartWave;
            Marker.OnDisableMarker += SotpWave;
        }

        private void Awake()
        {
            CountEnemy = _Spawn.CountEnemy;
            Enemy = _Spawn.EnemyPrefab.GetComponent<EnemyController>();
            Enemy.PathPoint = _PathBuilder;
            _enemyPool = new PoolObject(Enemy.gameObject, CountEnemy, transform.position, new GameObject("EnemyPool").transform);
            GameObject _modelBuilding = Instantiate(_Spawn.ModelPrefab, transform.position,transform.rotation, transform);
            _modelBuilding.transform.SetParent(transform); 
        }


        private IEnumerator WaveEnemys()
        {
            for ( int i = CurentEnemy; i < _Spawn.CountEnemy; i++)
            {
                EnemyController enemy = _enemyPool.GetObjectFromPool().GetComponent<EnemyController>();
                enemy.transform.position = transform.position;
                enemy.Health = _Spawn.Health;
                enemy.speed = _Spawn.Speedenemy;
                enemy.Damage = _Spawn.Damage;
                yield return new WaitForSeconds(_Spawn.RateInstantce);
                CurentEnemy++;
            }
        }

        public void StartWave()
        {
            waveCoroutine =  StartCoroutine(WaveEnemys());            
        }

        public static  bool CheckEndGame()
        {
            if (CurentEnemy != (CountEnemy)) return false;
                foreach (var item in _enemyPool.PoolObjects)
                {
                    if (item.activeInHierarchy)
                        return false;
                }

            return true;
        }
        
        private void OnDestroy()
        {
            GameManager.OnStartGame -= StartWave;
            Marker.OnDisableMarker -= SotpWave;
        }

        private void SotpWave(Marker marker)
        {
            if(waveCoroutine != null)
                StopCoroutine(waveCoroutine);
        }
    }
}
