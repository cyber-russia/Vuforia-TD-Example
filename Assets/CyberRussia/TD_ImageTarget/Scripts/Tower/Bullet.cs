using UnityEngine;


namespace CyberRussia.ARTDImageTarget
{
    public class Bullet : MonoBehaviour
    {
        public float Speed = 2;
        public float LifeTime;
        public float _time = 0;
        public float AngleSpray = 5;
        public int Damage = 5;
        public Vector3 _randomDirection;
        
        private void OnEnable()
        {
            _randomDirection = Quaternion.Euler(0, Random.Range(-AngleSpray, AngleSpray), 0) * Vector3.forward;
            _time = 0;
        }
        
        private void Update()
        {
            Shot();
            
            _time += Time.deltaTime;
            if(_time > LifeTime)
                gameObject.SetActive(false);
        }

        public void Shot()
        {
            transform.Translate(_randomDirection * Speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<EnemyController>().Health -= Damage;
            gameObject.SetActive(false);
            
        }
    }
}