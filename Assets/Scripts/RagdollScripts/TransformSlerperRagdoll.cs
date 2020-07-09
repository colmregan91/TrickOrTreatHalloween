using UnityEngine;

public class TransformSlerperRagdoll
{
    private Transform _animTempTrans;
    private Transform _ajTransform;
    private float SLerpStartTime;
    public float SLerpDuration = 1f;
    private animInformationReceiver _animInformationReceiver;
    private bool slerpTransNow;

    private RagdollTransformData _rdgransData;
    private RagdollEventHandler _rdgEvents;

    public TransformSlerperRagdoll(RagdollEventHandler rdgEvents, RagdollTransformData rdgransData, animInformationReceiver AnimTemplate, Transform ajTransform, Transform templateTransform)
    {
        _animTempTrans = templateTransform;
        _ajTransform = ajTransform;
        _animInformationReceiver = AnimTemplate;

        _rdgransData = rdgransData;

        _rdgEvents = rdgEvents;

       // _rdgEvents.AnimSlerpToPose += SetSlerpStartTime;
       // _rdgEvents.StandUpPlayer += ResetAnimSlerp;
       // _rdgEvents.SetTemplatePose += SetTemplatePose;
    }
    ~TransformSlerperRagdoll()
    {
    //  //  _rdgEvents.AnimSlerpToPose -= SetSlerpStartTime;
    //    _rdgEvents.StandUpPlayer -= ResetAnimSlerp;
       // _rdgEvents.SetTemplatePose -= SetTemplatePose;
    }

    public void SetSlerpStartTime(bool value)
    {
        slerpTransNow = value;
        SLerpStartTime = Time.time;
    }
    public void SetTemplatePose(bool upwards)
    {
        if (upwards)
        {
            //_animInformationReceiver.SetTemplatePose("GetUpBack");
        }
        else
        {
           // _animInformationReceiver.SetTemplatePose("GetUpFront");
        }
    }

    public void Tick()
    {
        if (slerpTransNow)
        {

            _animTempTrans.rotation = _ajTransform.transform.rotation;
            float timeSinceStarted = (Time.time - SLerpStartTime);
            float percentageComplete = (timeSinceStarted / SLerpDuration);

          //  _rdgransData.SlerpTransforms(_ajTransform, _animTempTrans, percentageComplete);
        }

    }

    internal void ResetAnimSlerp(bool f,animInformationReceiver d)
    {
        slerpTransNow = false;
    }
}

