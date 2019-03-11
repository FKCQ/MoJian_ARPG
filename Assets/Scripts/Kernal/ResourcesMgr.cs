using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Kernal {
    public class ResourcesMgr : MonoBehaviour
    {
        private static ResourcesMgr _instance;
        private Hashtable _resCache = null;
        private ResourcesMgr ()
        {
            _resCache = new Hashtable();
        }

        public static ResourcesMgr GetInstance()
        {
            //本类继承于MonoBehaviour，需要挂在物体上
            if(_instance == null)
            {
                _instance = new GameObject("ResourceMgr").AddComponent<ResourcesMgr>();
            }
            return _instance;
        }

        public T LoadResource<T>(string path, bool isAddToCache) where T : Object
        {
            if (_resCache.Contains(path))
            {
                return _resCache[path] as T;
            }

            T TResource = Resources.Load<T>(path);
            if (TResource == null)
            {
                Debug.LogWarning("'LoadResource()'TResource can not be found");
            }
            else if (isAddToCache)
            {
                _resCache.Add(path, TResource);
            }
            return TResource;
        }

        public GameObject LoadAsset(string path, bool isAddToCache)
        {
            GameObject go = LoadResource<GameObject>(path, isAddToCache);
            GameObject goClone = GameObject.Instantiate<GameObject>(go);

            if(goClone == null)
            {
                Debug.LogWarning("'LoadAsset()'goClone Instantiate failed,Make sure Path = " + path);
            }
            return goClone;
        }
    }
}


