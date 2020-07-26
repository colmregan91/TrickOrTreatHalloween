
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pool : MonoBehaviour
{
    private static Dictionary<PooledMonoBehavior, Pool> pools = new Dictionary<PooledMonoBehavior, Pool>();
    public Queue<PooledMonoBehavior> poolQueue = new Queue<PooledMonoBehavior>();
    public PooledMonoBehavior PooledObjectPrefab;

    public static Pool GetPool(PooledMonoBehavior prefab)
    {
        if (pools.ContainsKey(prefab))
        {
            return pools[prefab];
        }


        var newPool = new GameObject("pool -" + prefab.name).AddComponent<Pool>();
        newPool.PooledObjectPrefab = prefab;
        pools.Add(prefab, newPool);
        newPool.GrowPool();

        return newPool;
    }

    public T Get<T>() where T : PooledMonoBehavior
    {
        if (poolQueue.Count < 1)
        {
            GrowPool();
        }
        var pooledObj = poolQueue.Dequeue();
        return pooledObj as T;
    }

    private void GrowPool()
    {
        for (int i = 0; i < PooledObjectPrefab.initilalPoolSize; i++)
        {
            var pooledObj = Instantiate(PooledObjectPrefab) as PooledMonoBehavior;
            pooledObj.OnReturnToPool += ReturnToPool;

            pooledObj.transform.SetParent(this.transform);


            pooledObj.gameObject.SetActive(false);

            if (!poolQueue.Contains(pooledObj))
            {
                poolQueue.Enqueue(pooledObj);

            }
        }
    }

    public void AddToPool(PooledMonoBehavior pooledObj)
    {
        pooledObj.OnReturnToPool += ReturnToPool;

        pooledObj.transform.SetParent(this.transform);


        pooledObj.gameObject.SetActive(false);

        if (!poolQueue.Contains(pooledObj))
        {
            poolQueue.Enqueue(pooledObj);

        }

    }

    //public static void AddToPool(PooledMonoBehavior prefab)
    //{
    //    var pool = GetPool(prefab);

    //}

    private void ReturnToPool(PooledMonoBehavior PooledObj)
    {
        PooledObj.transform.localPosition = Vector3.zero;

        poolQueue.Enqueue(PooledObj);
    }

}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AddressableAssets;
//public class Pool : MonoBehaviour
//{

//    public static Dictionary<PooledMonobehaviour, Pool> pools = new Dictionary<PooledMonobehaviour, Pool>();
//    public Queue<PooledMonobehaviour> ThisPoolQueue = new Queue<PooledMonobehaviour>();
//    public AssetReference myObject;

//    void StartBulletPoolCoro(AssetReference obj, int PoolSize)
//    {
//        StartCoroutine(GrowBulletPool(obj, PoolSize));
//    }
//    private IEnumerator GrowBulletPool(AssetReference obj, int PoolSize)
//    {
//        for (int i = 0; i < PoolSize; i++)
//        {

//            var operation = obj.InstantiateAsync();
//            yield return operation;
//            PooledMonobehaviour pooledObject = operation.Result.GetComponent<PooledMonobehaviour>();
//            AddToPool(pooledObject);
//        }

//    }
//    public static Pool GetPool(PooledMonobehaviour prefab, AssetReference assetRef, int PoolSize)
//    {

//        if (pools.ContainsKey(prefab))
//        {
//            return pools[prefab];
//        }

//        var pool = new GameObject("Pool-" + (prefab as Component).name).AddComponent<Pool>();
//        pool.myObject = assetRef;
//        pools.Add(prefab, pool);
//        pool.StartBulletPoolCoro(assetRef, PoolSize);


//        return pool;
//    }

//    //public void CHeckEggPool()
//    //{
//    //    if (Eggs.Count <= 0)
//    //    {
//    //        for (int i = 0; i < 12; i++)
//    //        {

//    //            PooledMonobehaviour egg = ThrownEggs.Dequeue();
//    //            (egg as Component).gameObject.SetActive(false);
//    //            (egg as Component).transform.SetParent(this.transform);
//    //            (egg as Component).transform.localPosition = Vector3.zero; //me 
//    //            Eggs.Enqueue(egg);


//    //        }
//    //    }
//    //}

//    //public void ResetPool()
//    //{
//    //    // Debug.Log("begin reset count to " + (ShotProjectiles.Count / 2 + 1) );
//    //    int GetHalfofTotalBullets = ShotProjectiles.Count / 2;

//    //    for (int i = 0; i < GetHalfofTotalBullets; i++)
//    //    {

//    //        PooledMonobehaviour bul = ShotProjectiles.Dequeue();
//    //        (bul as Component).gameObject.SetActive(false);
//    //        (bul as Component).transform.SetParent(this.transform);
//    //        (bul as Component).transform.localPosition = Vector3.zero; //me 
//    //        projectileQueue.Enqueue(bul);


//    //    }
//    //      Debug.Log("buls" + projectileQueue.Count);

//    //  foreach (PooledMonobehaviour bul in ShotProjectiles)
//    //  {
//    //      int count = 0;
//    ////      ShotProjectiles.Dequeue();
//    //      projectileQueue.Enqueue(bul);
//    //      bul.gameObject.SetActive(false);
//    //      bul.transform.SetParent(posParent);
//    //      count++;
//    //      if (count == Bullets)
//    //      {
//    //          return;
//    //      }
//    //  }
//    //   Debug.Log("buls" + projectileQueue.Count);
//    //   Debug.Log("ShotBuls" + ShotProjectiles.Count);
//    //  }


//    public T Get<T>(Vector3 pos) where T : PooledMonobehaviour
//    {

//        var pooledObject = ThisPoolQueue.Dequeue();

//        if (pooledObject is projectile) // eont need this check after a while
//        {
//            pooledObject.transform.position = pos;
//            pooledObject.gameObject.SetActive(true);
//            if (ThisPoolQueue.Count < 1)
//            {
//               StartBulletPoolCoro(myObject, 5);
//            }
//            return pooledObject as T;
//        }

//        if (pooledObject is Candy)
//        {
//            pooledObject.transform.position = pos;
//            pooledObject.gameObject.SetActive(true);
//            return pooledObject as T;
//        }
//        return null;
//        //  }
//        //else if (typeRequested == "Egg")// ie if its not a bullet...
//        //{
//        //    var pooledObject = Eggs.Dequeue();
//        //    pooledObject.gameObject.SetActive(true);
//        //    ThrownEggs.Enqueue(pooledObject);

//        //    return pooledObject as T;

//        //}
//        //   else
//        //   {
//        //   Debug.LogError("type requested is null");
//        //      var pooledObject = Eggs.Dequeue();
//        //    return pooledObject as T;
//        ///  }

//    }

//    //public void GrowEggPool(int PoolSize)
//    //{
//    //    Eggs.Clear();
//    //    ThrownEggs.Clear();

//    //    for (int i = 0; i < PoolSize; i++)
//    //    {
//    //      //  var pooledObject = Instantiate(this.myprefab) as PooledMonobehaviour;
//    //        (pooledObject as Component).gameObject.name += " " + i;

//    //        if (pooledObject is projectile)
//    //        {
//    //            (pooledObject as Component).gameObject.SetActive(false);
//    //            (pooledObject as Component).transform.SetParent(this.transform);
//    //            (pooledObject as Component).transform.localPosition = Vector3.zero; //me 
//    //            Eggs.Enqueue(pooledObject);
//    //            //  pooledObject.OnDestroyEvent += () => AddObjectToAvailable(pooledObject);
//    //        }

//    //    }
//    //}


//    public void AddToPool(PooledMonobehaviour PooledType)
//    {
//        (PooledType as Component).gameObject.SetActive(false);
//        (PooledType as Component).transform.SetParent(this.transform);
//        (PooledType as Component).transform.localPosition = Vector3.zero; //me 

//        ThisPoolQueue.Enqueue(PooledType);
//        //  pooledObject.OnDestroyEvent += () => AddObjectToAvailable(pooledObject);
//    }

//}
