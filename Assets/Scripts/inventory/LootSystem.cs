using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Collections;
using System.Collections.Generic;
public class LootSystem : MonoBehaviour
{
    public static LootSystem _instance;
    [SerializeField] private AssetReference[] candyAddressables;
    private List<PooledMonoBehavior> pooledCandyRefs = new List<PooledMonoBehavior>();
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            _instance = this;
        }
    }

    private IEnumerator Start()
    {
       foreach (var candy in candyAddressables)
        {
            var operation = candy.InstantiateAsync();
            yield return operation;
            PooledMonoBehavior pooledObj = operation.Result.GetComponent<PooledMonoBehavior>();
            pooledCandyRefs.Add(pooledObj);

            Pool.GetPool(pooledObj);
            pooledObj.gameObject.SetActive(false);
        }
     
    }

    public static void AddCandy(int SweetsAmount/*, Transform DroppedTransform*/)
    {
        _instance.StartCoroutine(_instance.AddCandysAsync(SweetsAmount/*, DroppedTransform*/));
    }
    public static void PrepDropCandy(int SweetsAmount, Transform DroppedTransform)
    {
        _instance.DropCandy(SweetsAmount, DroppedTransform);
    }

    public void DropCandy(int SweetsAmount, Transform DroppedTransform)
    {
        for (int i = 0; i < SweetsAmount; i++)
        {
            int rand = Random.Range(0, pooledCandyRefs.Count);
            pooledCandyRefs[rand].Get<Candy>(DroppedTransform.position, Quaternion.identity);

        }
    }

    private IEnumerator AddCandysAsync(int SweetsAmount/*, Transform DroppedTransform*/)
    {
        for (int i = 0; i < SweetsAmount; i++)
        {
            int rand = Random.Range(0, candyAddressables.Length);
            var operation = candyAddressables[rand].InstantiateAsync();
            yield return operation;
            PooledMonoBehavior pooledObj = operation.Result.GetComponent<PooledMonoBehavior>();
            var pool = Pool.GetPool(pooledCandyRefs[rand]);
            pool.AddToPool(pooledObj);

        }
    }

    //private IEnumerator DropAllCandysAsync(int SweetsAmount, Transform DroppedTransform)
    //{

    //}


    //private IEnumerator DropLootAsync(Transform DroppedTransform)
    //{
    //    var operation = LootItemHolder.InstantiateAsync();
    //    yield return operation;
    //     ItemPickUpHolder itemHolder = operation.Result.GetComponent<ItemPickUpHolder>();

    //    //itemHolder.TakeSweet(Sweet);

    //    itemHolder.transform.position = DroppedTransform.position + Random.insideUnitSphere * 2;
    //}

}

