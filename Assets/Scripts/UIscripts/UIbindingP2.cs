//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class UIbindingP2 : MonoBehaviour, IBind
//{
//    [SerializeField] private ItemBasedEvent HandleItemChange;
//    [SerializeField] private NullableParamsEvent playertoRgdEvent;
//    [SerializeField] private NullableParamsEvent RgdtoPlayerEvent;
//    [SerializeField] private NullableParamsEvent HandleSweetPickUp;

//    [SerializeField] private NullableParamsEvent triggerEnterEvent;
//    [SerializeField] private NullableParamsEvent triggerExitEvent;
//    [SerializeField] private NullableParamsEvent TakingSweetseEvent;
//    [SerializeField] private NullableParamsEvent AwardSweetseEvent;


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
//        AwardSweetseEvent._ResponseP2 += functionPassed;
//    }
//    public void UnRegisterAwardSweetsEvent(Action<int?> functionPassed)
//    {
//        AwardSweetseEvent._ResponseP2 -= functionPassed;
//    }

//    public void RegisterForHandleTurning(Action<int?> functionPassed)
//    {
//        Debug.Log("bug if u get this message");
//    }

//    public void UnRegisterForHandleTurning(Action<int?> functionPassed)
//    {
//        Debug.Log("bug if u get this message");
//    }
//}
