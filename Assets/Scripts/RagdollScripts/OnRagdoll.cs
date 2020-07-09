using UnityEngine;

public class OnRagdoll : Istate
{
    private RagdollTransformData _rgdTransData;

    private RagdollUpdater RagdollUpdater;

    private Transform _AJtransform;
    private Transform _Ragdollransform;

    private float TimePlayerHit;
    private float RagdollDuration = 4;
    public bool continuetoNextState;
    public OnRagdoll(Transform Ragdollransform, Transform AjTtransform) // keeps pa
    {

        _AJtransform = AjTtransform;
        _Ragdollransform = Ragdollransform;

        Transform rgdSpine = _Ragdollransform.GetChild(1);


        _rgdTransData = new RagdollTransformData();
        RagdollUpdater = new RagdollUpdater(rgdSpine, _AJtransform.root); // keeps playerHolder in place according to rgdSpine pos

    }
    public void OnEnter()
    {
        RagdollSetter.PrepRagdoll(_AJtransform, _Ragdollransform);
        TimePlayerHit = Time.time;
    }

    public void OnExit()
    {

        continuetoNextState = false;
       
    }

    public void OnUpdate()
    {
        RagdollUpdater.Tick();

        if (Time.time >= TimePlayerHit + RagdollDuration)
        {
            continuetoNextState = true;
        }
    }
}
