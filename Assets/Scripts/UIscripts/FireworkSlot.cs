using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireworkSlot : MonoBehaviour
{
    private inventory _Inventory;
    private Image thisSprite;
    private IPlayer player => transform.root.GetComponent<IPlayer>();
    public playerEventHandler eventHandler; 

    void Awake()
    {
        eventHandler = transform.root.GetComponent<playerEventHandler>();
        thisSprite = GetComponentInChildren<Image>();
        thisSprite = transform.Find("Image").GetComponent<Image>();
    }
    private void Start()
    {
 

        eventHandler.HandleItemChange += FireworkChanged;
    }
    private void OnDisable()
    {
      //if (eventHandler == null)
      //  {
      //      Debug.Log(eventHandler);
      //      eventHandler = transform.root.GetComponent<playerEventHandler>();
      //  }
        eventHandler.HandleItemChange -= FireworkChanged; 
    }

    public void FireworkChanged(Item newFirework)
    {
        thisSprite.sprite = newFirework._icon;
    }

}
