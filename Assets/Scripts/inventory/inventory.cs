using System;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    private List<Item> _Items = new List<Item>();
    [SerializeField] private Transform RightHand;

    [SerializeField] private Transform ItemsHolder;
    private Vector3 initialHolderPos;
    private IPlayer player => GetComponent<IPlayer>();
    private playerEventHandler playerEvHandler;
    private void Start()
    {
        playerEvHandler = player.eventHandler;
        initialHolderPos = ItemsHolder.position;

        playerEvHandler.playertoRgdEvent += DropLoot;
        playerEvHandler.RgdtoPlayerEvent += PickUpLoot;
    }
    private void OnDisable()
    {

        playerEvHandler.playertoRgdEvent -= DropLoot;
        playerEvHandler.RgdtoPlayerEvent -= PickUpLoot;
    }
    public Item ActiveItem { get; private set; }
    public bool isLootDropped;

    public void DropLoot()
    {
        isLootDropped = true;
        foreach (Item item in _Items)
        {
            item.transform.SetParent(null);
        }

    }
    public void PickUpLoot()
    {
        isLootDropped = false;
        foreach (Item item in _Items)
        {
            item.transform.SetParent(ItemsHolder);
            item.transform.localRotation = Quaternion.identity;
            item.transform.localPosition = Vector3.zero;
        }
        // ItemsHolder.SetParent(RightHand);
        //   ItemsHolder.position = Vector3.zero;


    }
    public void Equip(Item item)
    {
        if (ActiveItem != null)
        {
            Unequip(ActiveItem);
        }
        Transform itemTransform = item.transform;
        _Items.Add(item);
        itemTransform.SetParent(ItemsHolder);
        item.transform.localRotation = Quaternion.identity;
        item.transform.localPosition = Vector3.zero;
        ActiveItem = item;

        playerEvHandler.RaiseHandleItemChange(ActiveItem);

        if (ActiveItem.ObjectType is FireworkObject)
        {

            FireworkObject newlyEquippedFirework = ActiveItem.ObjectType as FireworkObject;
            newlyEquippedFirework.SetMyPool();
        }
    }
    private void Unequip(Item item)
    {
        item.transform.SetParent(ItemsHolder);
        item.gameObject.SetActive(false);
    }
}

