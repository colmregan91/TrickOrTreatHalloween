using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class playerEventHandler : MonoBehaviour
{
    public event Action<int> HandleTurning;
    public event Action playertoRgdEvent;
    public event Action RgdtoPlayerEvent;
    public event Action<int> HandleSweetPickUp;
    public event Action<Item> HandleItemChange;
    public event Action<int> triggerEnterEvent;
    public event Action triggerExitEvent;
    public event Action AwardSweetsEvent;
    public event Action TakingSweetseEvent;
    public event Action<int> HandleSweetDropped;


    public void RaiseHandleTurning(int dot)
    {

        HandleTurning?.Invoke(dot);
    }

    public void RaiseplayertoRgdEvent()
    {
        playertoRgdEvent?.Invoke();
    }

    public void RaiseRgdtoPlayerEvent()
    {
        RgdtoPlayerEvent?.Invoke();
    }

    public void RaiseHandleSweetPickUp(int amount)
    {
        HandleSweetPickUp?.Invoke(amount);
    }
    public void RaiseHandleSweetDropped(int amount)
    {
        HandleSweetDropped?.Invoke(amount);
    }

    public void RaiseHandleItemChange(Item ActiveItem)
    {
        HandleItemChange?.Invoke(ActiveItem);
    }

    public void RaisetriggerEnterEvent(int infoIndex)
    {
        triggerEnterEvent?.Invoke(infoIndex);
    }

    public void RaisetriggerExitEvent()
    {
        triggerExitEvent?.Invoke();
    }

    public void RaiseAwardSweetsEvent()
    {
        AwardSweetsEvent?.Invoke();
    }

    public void RaiseTakingSweetseEvent()
    {
        TakingSweetseEvent?.Invoke();
    }

}



