using System.Collections.Generic;
using UnityEngine;

namespace Refactoring
{
    public class PoolObject<T> where T: MonoBehaviour
    {
        public PoolObject(GameObject prefabs, int count, Transform parent)
        {
            _prefabs = prefabs;
            _count = count;
            _parent = parent;
            SetPoolObject();
        }

        private GameObject _prefabs;
        private int _count;
        private List<GameObject> _pool = new List<GameObject>();
        private Transform _parent;

        private T Levon;

        void SetPoolObject()
        {
            for (int i = 0; i < _count; i++)
            {
                CreateObj();
            }
        }

        private GameObject CreateObj()
        {
            var obj = GameObject.Instantiate(_prefabs, _parent.position, _parent.rotation, _parent);
            obj.SetActive(false);
            obj.AddComponent<T>();
            _pool.Add(obj);
            return obj;
        }


        public T GetPoolObject()
        {
            for (int i = 0; i < _count; i++)
            {
                if (!_pool[i].activeInHierarchy)
                {
                    _pool[i].SetActive(true);
                    _pool[i].transform.localPosition = Vector3.zero;
                    _pool[i].transform.rotation = Quaternion.Euler(Vector3.zero);
                    
                    return _pool[i].GetComponent<T>();
                }
            }
            
            var obj = CreateObj();
            obj.SetActive(true);
            return obj.GetComponent<T>();
        }
    }
}