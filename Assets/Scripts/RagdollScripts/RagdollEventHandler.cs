using System;
using UnityEngine;

public class RagdollEventHandler
{
    Transform _AJtransform, _RagdollTransform;
    animInformationReceiver _animInformationReceiver;
    RagdollTransformData _rgdTransData;


    //public event Action<Transform, Transform, animInformationReceiver> SetRagdoll;
  //  public event Action<Transform, Transform> SetPlayer;
  //  public event Action<bool> CamSlerpToPosition;
    public event Action<bool> REsetCamPosition;
  //  public event Action<bool> AnimSlerpToPose;
    public event Action<bool> REsetAnimSlerp;
   // public event Action<bool> SetTemplatePose;
 //   public event Action<bool, animInformationReceiver> StandUpPlayer;

    public event Action PlayerHit;
    public event Action PlayerRecovered;
    public RagdollEventHandler(Transform aj, Transform rdg, animInformationReceiver animInformationReceiver)
    {
        _AJtransform = aj;
        _RagdollTransform = rdg;
        _animInformationReceiver = animInformationReceiver;
    }

    public void SetRagdollEv()
    {
        //SetRagdoll?.Invoke(_AJtransform, _RagdollTransform, _animInformationReceiver);
    }
    public void setPlayerEv()
    {
     //   SetPlayer?.Invoke(_AJtransform, _RagdollTransform);
    }

    public void CamSlerpToPositionEv()
    {
   //     CamSlerpToPosition?.Invoke(true);
    }

    public void REsetCamPositionEv()
    {
        REsetCamPosition?.Invoke(false);
    }

    public void AnimSlerpToPoseEv()
    {
        //AnimSlerpToPose?.Invoke(true);
    }
    public void ResetAnimSlerpEv()
    {
        REsetAnimSlerp?.Invoke(false);
    }
    public void SetTemplatePoseEv(bool isUpwards)
    {

    //    SetTemplatePose?.Invoke(isUpwards);
    }

    public void StandUpPlayerEv(bool isUpwards)
    {
        //StandUpPlayer?.Invoke(isUpwards, _animInformationReceiver); 
    }
    public void PlayerHitEv()
    {
        PlayerHit?.Invoke();
    }
    public void PlayerRecoveredEv()
    {
        PlayerRecovered?.Invoke();
    }

}

