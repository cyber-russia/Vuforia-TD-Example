using UnityEngine;

namespace SupremumStudio
{
    public class TowerController: MonoBehaviour
    {
        public Transform SpawnBullet;
        public Tower Tower;

        private PoolObject bulletPool;

        private void Awake()
        {
//            var parent = new GameObject("Bullets");
//            parent.transform.position = SpawnBullet.position;
            
            bulletPool = new PoolObject(Tower.Bullet, 20, new GameObject("Bullets"));
            InvokeRepeating("Fire",3, 0.3f);
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