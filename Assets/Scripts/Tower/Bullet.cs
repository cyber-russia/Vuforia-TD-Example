using UnityEngine;

namespace SupremumStudio
{
    public class Bullet: MonoBehaviour
    {
        private Vector3 _startposition;
        private float _dt;
        public int LifeTime =2;
        public float SpeedBullet=2;
        public float AngleSpray;
        public int Damage;
        private Vector3 _randomSparay;
        
        private void OnEnable()
        {
            _dt = 0;
            _startposition = transform.position;
            _randomSparay = Quaternion.Euler(0,Random.Range(-AngleSpray,AngleSpray),0)*Vector3.forward;
        }

        private void Update()
        {
            transform.Translate(_randomSparay*Time.deltaTime*SpeedBullet);   //whit directional
//            transform.position = transform.position + Vector3.forward * Time.deltaTime * SpeedBullet;  //whitout directional
            
            _dt += Time.deltaTime;
            if (_dt>LifeTime)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnDisable()
        {
            transform.position = _startposition;
        }

        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<Enemy>().Health -= Damage;
        }
    }
}