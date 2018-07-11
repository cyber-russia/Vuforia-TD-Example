using System.Collections.Generic;
using UnityEngine;

namespace CyberRussia.ARTDImageTarget
{
    public class PoolObject
    {
        private GameObject _prefab;
        private int _countObject;
        private List<GameObject> _poolObjects = new List<GameObject>();
        private Vector3 _startPosition;
        private Transform _parent;
        
        public List<GameObject> PoolObjects
        {
            get { return _poolObjects; }
        }

        public PoolObject(GameObject prefab, int countObject, Vector3 startPosition, Transform parent)
        {
            _prefab = prefab;
            _countObject = countObject;
            _startPosition = startPosition;
            _parent = parent;
            CreatePoolObjects();
        }

        private GameObject CreateObject()
        {
            GameObject _object = GameObject.Instantiate(_prefab);
            _object.transform.SetParent(_parent);
            _object.SetActive(false);
            _poolObjects.Add(_object);
            return _object;
        }

        private void CreatePoolObjects()
        {
            for (int i = 0; i < _countObject; i++)
            {
                CreateObject();
            }
        }

        public GameObject GetObjectFromPool()
        {
            for (int i = 0; i < _countObject; i++)
            {
                if (!_poolObjects[i].activeInHierarchy)
                {
                    _poolObjects[i].SetActive(true);
                    _poolObjects[i].transform.localPosition = _startPosition;
                    _poolObjects[i].transform.rotation = Quaternion.Euler(Vector3.zero);
                    return _poolObjects[i];
                }
            }

            GameObject _object = CreateObject();
            _object.SetActive(true);
            return _object;
        }
    }
}