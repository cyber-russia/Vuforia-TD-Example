using UnityEngine;

namespace SupremumStudio
{
    public class TowerController : MonoBehaviour
    {
        public Transform SpawnBullet;
        public Tower Tower;

        private PoolObject bulletPool;
        private GameObject _modelTower;

        private void Awake()
        {
            _modelTower = Instantiate(Tower.TowerModel, transform.position, transform.rotation, transform);
            _modelTower.name = "Tower";
            bulletPool = new PoolObject(Tower.Bullet, 20, new GameObject("Bullets"));
            
            GameManager.StartGame += StartFire;
        }

        public void StartFire()
        {
            InvokeRepeating("Fire", 3, 0.3f);
        }


        void Fire()
        {
            var b = bulletPool.GetBullet();
            b.AngleSpray = Tower.SprayAngle;
            b.Damage = Tower.Damage;
            b.transform.position = SpawnBullet.position;
            b.transform.rotation = SpawnBullet.transform.parent.rotation;
        }
    }
}