using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chipinators
{
    public abstract class ObjectPooler : MonoBehaviour
    {
        [SerializeField] protected GameObject objectPrefab;
        [SerializeField] protected Transform objectHolder;
        [SerializeField] protected int startSize = 20;

        protected Stack<GameObject> pool;

        protected Stack<GameObject> queuedForDestroy;

        private bool initialized = false;

        protected virtual void Awake()
        {

            pool = new Stack<GameObject>(startSize);
            queuedForDestroy = new Stack<GameObject>();

            objectHolder = (objectHolder ? objectHolder : transform);

            InitializePoolObjects();
        }

        /// <summary>
        /// Instantiate startSize objects to the pool.
        /// </summary>
        void InitializePoolObjects()
        {
            if (initialized) return;
            initialized = true;

            for (int i = 0; i < startSize; i++)
            {
                AddObjectToPool();
            }

        }

        /// <summary>
        /// Instantiate a new object to the pool.
        /// </summary>
        protected void AddObjectToPool()
        {
            GameObject obj = Instantiate(objectPrefab, objectHolder);
            obj.SetActive(false);
            pool.Push(obj);
        }

        /// <summary>
        /// Get an existing object from the pool.
        /// </summary>
        /// <returns></returns>
        protected GameObject GetFromPool()
        {
            if (pool.Count == 0)
            {
                AddObjectToPool();
            }

            return pool.Pop();
        }

        /// <summary>
        /// Returns the given GameObject back to the pool. 
        /// If queueForDestroy is True the object will be added to the pool during LateUpdate.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="queueForDestroy"></param>
        protected void ReturnToPool(GameObject obj, bool queueForDestroy = false)
        {
            obj.SetActive(false);

            if (queueForDestroy)
            {
                queuedForDestroy.Push(obj);
            }
            else
            {
                pool.Push(obj);
            }
        }

        /// <summary>
        /// Return all pool objects back to the pool.
        /// </summary>
        protected void ReturnAllToPool()
        {
            foreach (Transform obj in objectHolder)
            {
                ReturnToPool(obj.gameObject);
            }
        }

        void LateUpdate()
        {
            while (queuedForDestroy.Count > 0)
            {
                ReturnToPool(queuedForDestroy.Pop());
            }
        }
    }
}