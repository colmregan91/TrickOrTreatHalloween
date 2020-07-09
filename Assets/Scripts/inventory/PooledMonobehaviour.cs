using UnityEngine;
using System;
public class PooledMonoBehavior : MonoBehaviour
{
    [SerializeField] protected int initialPoolSize = 50;
    public int initilalPoolSize { get { return initialPoolSize; } protected set { initialPoolSize = value; } }


    public event Action<PooledMonoBehavior> OnReturnToPool;

    protected virtual void OnDisable()
    {
        
        OnReturnToPool?.Invoke(this);
    }

    public T Get<T>(bool shouldEnable = true) where T : PooledMonoBehavior
    {
        var pool = Pool.GetPool(this);
        var pooledObj = pool.Get<T>();

        if (shouldEnable)
        {

            pooledObj.gameObject.SetActive(true);
        }
        return pooledObj;
    }

    public T Get<T>(Vector3 position, Quaternion rotation) where T : PooledMonoBehavior
    {
        var pooledObj = Get<T>();

        pooledObj.transform.position = position;
        pooledObj.transform.rotation = rotation;

        return pooledObj;
    }

    protected void ReturnToPool(float delay = 0)
    {
        Invoke("BackToPool", delay);
    }

    public void SetPosition(Transform targetpos)
    {
        transform.position = targetpos.position;
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;

//public class PooledMonobehaviour : MonoBehaviour
//{

//    private Pool objectpool;

//    private protected void OnEnable()
//    {
//        if (objectpool == null)
//        {

//            objectpool = transform.root.GetComponent<Pool>();

//        }

//        transform.SetParent(null);
//    }
//    protected void ResetObject(PooledMonobehaviour obj)
//    {

//        objectpool.AddToPool(obj);
//    }

//    public T Get<T>(Pool pool, Vector3 pos) where T : PooledMonobehaviour
//    {

//        var pooledObject = pool.Get<T>(pos);

//        return pooledObject;
//    }

//    //public T Get<T>(Transform parent, bool resetTransform = true) where T : PooledMonobehaviour
//    //{
//    //    var pooledObject = Get<T>(true);
//    //    pooledObject.transform.SetParent(parent);

//    //    if (resetTransform)
//    //    {
//    //        Debug.Log("resetT");
//    //        pooledObject.transform.localPosition = Vector3.zero;
//    //        pooledObject.transform.localRotation = Quaternion.identity;
//    //    }

//    //    return pooledObject;
//    //}



//    //public T Get<T>(Transform parent, Vector3 relativePosition, Quaternion relativeRotation) where T : PooledMonobehaviour
//    //{
//    //    var pooledObject = Get<T>(true);
//    //    pooledObject.transform.SetParent(parent);

//    //    pooledObject.transform.localPosition = relativePosition;
//    //    pooledObject.transform.localRotation = relativeRotation;

//    //    return pooledObject;
//    //}
//}
