using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class slotHandler : MonoBehaviour
{
    public Image[] SlotSprites;
    private playerEventHandler eventHandler;

    private int FireworkSlotIndex = 0;
    private int EggSlotIndex = 1;

    public Image selectorImage;
    void Awake()
    {
        eventHandler = transform.root.GetComponent<playerEventHandler>();

    }
    private void Start()
    {
        selectorImage.gameObject.SetActive(false);
        eventHandler.HandleItemChange += ItemChanged;
    }
    private void OnDisable()
    {                                                                    
        eventHandler.HandleItemChange -= ItemChanged;
    }
    void TurnOn()
    {
        if (!selectorImage.gameObject.activeSelf)
        {
            selectorImage.gameObject.SetActive(true);
        }
    }

    public void ItemChanged(Item newItem)
    {
        TurnOn();
        if (newItem.ObjectType is FireworkObject)
        {
            Debug.Log(newItem.ObjectType);
            AssignWeaponToSlot(newItem, FireworkSlotIndex);
            return;
        }
        if (newItem.ObjectType is EggObject)
        {
            Debug.Log(newItem.ObjectType);
            AssignWeaponToSlot(newItem, EggSlotIndex);
            return;
        }
    }

    void AssignWeaponToSlot(Item item, int slotIndex)
    {
        SlotSprites[slotIndex].sprite = item._icon;
        Debug.Log(SlotSprites[slotIndex]);
        selectorImage.rectTransform.position = SlotSprites[slotIndex].rectTransform.parent.position;
    }
}
