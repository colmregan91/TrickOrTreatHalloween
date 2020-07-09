using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ItemPickUpHolder : MonoBehaviour
{
    public float rotateSpeed = 5;


    //public void TakeItem(Item item)
    //{
    //    Transform itemTransform = item.transform;
    //    itemTransform.localPosition = Vector3.zero;
    //    itemTransform.localRotation = Quaternion.identity;
    //    item.transform.SetParent(itemTransform);
    //    item.gameObject.SetActive(true);
    //    item.wasPickedUp = true;
    //}

    private void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
