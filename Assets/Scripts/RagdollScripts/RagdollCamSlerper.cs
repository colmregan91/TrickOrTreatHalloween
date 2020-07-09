using UnityEngine;

public class RagdollCamSlerper
{
    private Transform _Playerhead;
    private Transform _playerSpine;

    private Transform _Cambase;
    private bool slerpCam;
    private bool slerpTransNow;
    private float SLerpStartTime;
    private float SLerpDuration = 2f;
    private bool onecall = true;
    Quaternion GetForward;
    RagdollEventHandler _RdgEvents;
    public float _slerpDuration => SLerpDuration;

    public RagdollCamSlerper(Transform HeadPos, Transform SpinePos, Transform CamBase)
    {
        _Playerhead = HeadPos;
        _playerSpine = SpinePos;
    
        _Cambase = CamBase;
   

 //       _RdgEvents.CamSlerpToPosition += SetCamSlerpStartTime;
     //   _RdgEvents.PlayerRecovered += ResetSlerpCam;
    }
    //~RagdollCamSlerper()
    //{
    ////    _RdgEvents.CamSlerpToPosition -= SetCamSlerpStartTime;
    //    _RdgEvents.PlayerRecovered -= ResetSlerpCam;
    //}    ~RagdollCamSlerper()
    //{
    ////    _RdgEvents.CamSlerpToPosition -= SetCamSlerpStartTime;
    //    _RdgEvents.PlayerRecovered -= ResetSlerpCam;
    //}

    public void SetCamSlerpStartTime(bool value)
    {
        slerpTransNow = value;
        SLerpStartTime = Time.time;
    }

    public bool upwards()
    {
        bool upwards = _playerSpine.up.y > 0.0f;
        return upwards;
    }
    void SlerpCam(Vector3 from, Vector3 to)
    {
        if (slerpTransNow)
        {
            Vector3 covFrom = new Vector3(from.x, 0, from.z);
            Vector3 covTo = new Vector3(to.x, 0, to.z);

            if (onecall)
            {
                GetForward = Quaternion.LookRotation(covFrom - covTo);
                onecall = false;
                Debug.Log("onecall");
            }


            float timeSinceStarted = (Time.time - SLerpStartTime);
            float percentageComplete = (timeSinceStarted / SLerpDuration);

      //      _PlayerTransform.rotation = Quaternion.Slerp(_PlayerTransform.rotation, GetForward, percentageComplete);

            _Cambase.rotation = Quaternion.Slerp(_Cambase.rotation, GetForward, percentageComplete);
            GetForward.x = 0;

        }
    }
    public void Tick()
    {
        //Vector3 g = _playerSpine.InverseTransformVector(_playerSpine.up);
        //bool upwards = _playerSpine.up.y > 0.0f; // changed from forward to up
        if (upwards())
        {


            SlerpCam(_playerSpine.position, _Playerhead.position);

        }
        else
        {

            //  _anim.CrossFade("GetUpFrontGen", 0);
            SlerpCam(_Playerhead.position, _playerSpine.position);

        }
    }

    public void ResetSlerpCam()
    {
        onecall = true;
        slerpTransNow = false;

    }
}

