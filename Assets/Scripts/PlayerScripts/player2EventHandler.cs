//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;
//public class player2EventHandler : MonoBehaviour, IBind, iRaiseEvents
//{
//    public NullableParamsEvent HandleTurning;
//    public NullableParamsEvent playertoRgdEvent;
//    public NullableParamsEvent RgdtoPlayerEvent;
//    public NullableParamsEvent HandleSweetPickUp;
//    public ItemBasedEvent HandleItemChange;
//    public NullableParamsEvent triggerEnterEvent;
//    public NullableParamsEvent triggerExitEvent;
//    public NullableParamsEvent AwardSweetsEvent;
//    public NullableParamsEvent TakingSweetseEvent;
//    //private playerSettings playersettingsRef;

//    //public playerSettings PlayerSettings { get { return playersettingsRef; } }

//    public void RegisterForHandleITemChange(Action<Item> functionPassed)
//    {
//        HandleItemChange._ResponseP2 += functionPassed;
//    }
//    public void UnRegisterForHandleITemChange(Action<Item> functionPassed)
//    {
//        HandleItemChange._ResponseP2 -= functionPassed;
//    }


//    public void RegisterForPlayerToRGD(Action<int?> functionPassed)
//    {
//        playertoRgdEvent._ResponseP2 += functionPassed;
//    }
//    public void UnRegisterForPlayerToRGD(Action<int?> functionPassed)
//    {
//        playertoRgdEvent._ResponseP2 -= functionPassed;
//    }


//    public void RegisterForRGDtoPlayer(Action<int?> functionPassed)
//    {
//        RgdtoPlayerEvent._ResponseP2 += functionPassed;
//    }
//    public void UnRegisterForRGDtoPlayer(Action<int?> functionPassed)
//    {
//        RgdtoPlayerEvent._ResponseP2 -= functionPassed;
//    }

//    public void RegisterForHandleSweetPickedUp(Action<int?> functionPassed)
//    {
//        HandleSweetPickUp._ResponseP2 += functionPassed;
//    }
//    public void UnRegisterForHandleSweetPickedUp(Action<int?> functionPassed)
//    {
//        HandleSweetPickUp._ResponseP2 -= functionPassed;
//    }

//    public void RegistertriggerEnterEvent(Action<int?> functionPassed)
//    {
//        triggerEnterEvent._ResponseP2 += functionPassed;
//    }
//    public void UnRegistertriggerEnterEvent(Action<int?> functionPassed)
//    {
//        triggerEnterEvent._ResponseP2 -= functionPassed;
//    }
//    public void RegistertriggerExitEvent(Action<int?> functionPassed)
//    {
//        triggerExitEvent._ResponseP2 += functionPassed;
//    }
//    public void UnRegistertriggerExitEvent(Action<int?> functionPassed)
//    {
//        triggerExitEvent._ResponseP2 -= functionPassed;
//    }
//    public void RegistertakingSweetsEvent(Action<int?> functionPassed)
//    {
//        TakingSweetseEvent._ResponseP2 += functionPassed;
//    }
//    public void UnRegistertakingSweetsEvent(Action<int?> functionPassed)
//    {
//        TakingSweetseEvent._ResponseP2 -= functionPassed;
//    }

//    public void RegisterAwardSweetsEvent(Action<int?> functionPassed)
//    {
//        AwardSweetsEvent._ResponseP2 += functionPassed;
//    }
//    public void UnRegisterAwardSweetsEvent(Action<int?> functionPassed)
//    {
//        AwardSweetsEvent._ResponseP2 -= functionPassed;
//    }

//    public void RegisterForHandleTurning(Action<int?> functionPassed)
//    {
//        HandleTurning._ResponseP2 += functionPassed;
//    }

//    public void UnRegisterForHandleTurning(Action<int?> functionPassed)
//    {
//        HandleTurning._ResponseP2 -= functionPassed;
//    }

//    public void RaiseHandleTurning(int dot)
//    {
//        HandleTurning.RaiseIntBasedEventP2(dot);
//    }

//    public void RaiseplayertoRgdEvent()
//    {
//        playertoRgdEvent.RaiseNoParamBasedEventP2();
//    }

//    public void RaiseRgdtoPlayerEvent()
//    {
//        RgdtoPlayerEvent.RaiseNoParamBasedEventP2();
//    }

//    public void RaiseHandleSweetPickUp(int sweetsAmount)
//    {
//        HandleSweetPickUp.RaiseIntBasedEventP2(sweetsAmount);
//    }

//    public void RaiseHandleItemChange(Item ActiveItem)
//    {
//        HandleItemChange.RaiseItemBasedEventP2(ActiveItem);
//    }

//    public void RaisetriggerEnterEvent(int? infoIndex)
//    {
//        triggerEnterEvent.RaiseIntBasedEventP2(infoIndex.Value);
//    }

//    public void RaisetriggerExitEvent()
//    {
//        triggerExitEvent.RaiseNoParamBasedEventP2();
//    }

//    public void RaiseAwardSweetsEvent()
//    {
//        AwardSweetsEvent.RaiseNoParamBasedEventP2();
//    }

//    public void RaiseTakingSweetseEvent()
//    {
//        TakingSweetseEvent.RaiseNoParamBasedEventP2();
//    }

//}
