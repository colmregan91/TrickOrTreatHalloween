using UnityEngine;

public class OnRagdoll : Istate
{
    private RagdollTransformData _rgdTransData;

    private RagdollUpdater RagdollUpdater;

    private Transform _AJtransform;
    private Transform _Ragdollransform;
    private Transform _RGDSpine;
    private float TimePlayerHit;
    private float RagdollDuration = 4;
    public bool continuetoNextState;
    private Rigidbody ragdollRB;
   
    public OnRagdoll(Transform Ragdollransform, Transform AjTtransform, Transform RGDSpine) // keeps pa
    {

        _AJtransform = AjTtransform;
        _Ragdollransform = Ragdollransform;
        ragdollRB = _Ragdollransform.GetComponent<Rigidbody>();

        _RGDSpine = RGDSpine;

        _rgdTransData = new RagdollTransformData();
        RagdollUpdater = new RagdollUpdater(_RGDSpine, _AJtransform.root); // keeps playerHolder in place according to rgdSpine pos
        Debug.Log(_RGDSpine);
        Debug.Log(_AJtransform.root);
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

        if (Time.time >= TimePlayerHit + RagdollDuration && ragdollRB.velocity == Vector3.zero)
        {
            continuetoNextState = true;
        }
    }
}
