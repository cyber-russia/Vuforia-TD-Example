using System.Collections.Generic;
using UnityEngine;

namespace SupremumStudio
{
    public class PoolObject
    {
        public PoolObject(GameObject poolObj, int count, GameObject parentPool)
        {
            _prefabs = poolObj;
            _count = count;
            _pool = new List<GameObject>();
            _parent = parentPool.transform;
            SetPoolObjects();
        }

        private GameObject _prefabs;
        private int _count;

        private List<GameObject> _pool;
        private Transform _parent;

        void SetPoolObjects()
        {
            for (int i = 0; i < _count; i++)
            {
                CreateObj();
            }
        }

       public  List<GameObject> PoolObjects 
        {
            get { return _pool; }
        }

        private GameObject CreateObj()
        {
            var o = GameObject.Instantiate(_prefabs); //todo: брать скиптейбл
            o.transform.SetParent(_parent.transform);
            o.SetActive(false);
            _pool.Add(o);
            return o;
        }

        public Bullet GetBullet() //TODO: change T
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].activeInHierarchy)
                {
                    _pool[i].SetActive(true);
                    _pool[i].transform.localPosition = Vector3.zero;
                    _pool[i].transform.rotation = Quaternion.Euler(Vector3.zero);

                    return _pool[i].GetComponent<Bullet>();
                }
            }

            var obj = CreateObj();
            obj.SetActive(true);
            return obj.GetComponent<Bullet>();
        }

        public Enemy GetEnemy() //TODO: change T
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].activeInHierarchy)
                {
                    _pool[i].SetActive(true);
                    _pool[i].transform.localPosition = Vector3.zero;
                    _pool[i].transform.rotation = Quaternion.Euler(Vector3.zero);

                    return _pool[i].GetComponent<Enemy>();
                }
            }

            var obj = CreateObj();
            obj.SetActive(true);
            return obj.GetComponent<Enemy>();
        }
        
        public GameObject GetPoolObject()
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].activeInHierarchy)
                {
                    _pool[i].SetActive(true);
                    _pool[i].transform.localPosition = Vector3.zero;
                    _pool[i].transform.rotation = Quaternion.Euler(Vector3.zero);

                    return _pool[i];
                }
            }

            var obj = CreateObj();
            obj.SetActive(true);
            return obj;
        }





    }

}
