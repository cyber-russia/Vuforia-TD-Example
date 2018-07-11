using UnityEngine;

namespace CyberRussia.ARTDImageTarget
{
    public class TowerController : MonoBehaviour
    {
        public Tower _Tower;
        public Transform SpawnBullet;
        public GameObject Bullet;
        private PoolObject _bulletPool;
        private float rate;
        
        private void Awake()
        {
            GameObject _modelBuilding = Instantiate(_Tower.TowerModel, transform.position, transform.rotation, transform);
            _modelBuilding.transform.SetParent(transform);
            _bulletPool = new PoolObject(Bullet, 10, SpawnBullet.position, new GameObject("BulletPull").transform);
        }

        private void Start()
        {
            GameManager.OnStartGame += StartFier;
        }

        public void Fire()
        {
            Bullet bullet = _bulletPool.GetObjectFromPool().GetComponent<Bullet>();
            bullet.AngleSpray = _Tower.SprayAngle;
            bullet.Speed = _Tower.ShooterSpeed;
            bullet.Damage = _Tower.Damage;
            bullet.transform.position = SpawnBullet.position;
            bullet.transform.rotation = SpawnBullet.rotation;
        }

        void StartFier()
        {
           InvokeRepeating("Fire", 0.2f, _Tower.Rate); 
        }

        private void OnDisable()
        {
            
        }
    }
}