using UnityEngine;

public class CorrectingCameraPositionAndLerpingTransforms : Istate
{
    private animationControl _animCont;
    private Transform _cambase;
    private Transform _Rgd1;
    private Transform _ajTransform;
    private Transform _rgdTransform;
    private Transform _Rgd2;
    private bool isFacingUp;
    private float SLerpStartTime;
    private Quaternion Forward;
    private float SLerpDuration = 4;
    private float SLerpSTransormstartTime;
    private float TransformsSLerpDuration = 3f;

    public bool Ready = false;

    public CorrectingCameraPositionAndLerpingTransforms(Transform CamBase, animationControl animCont, Transform AJTransform, Transform RGDTransform, Transform one, Transform two)
    {
        _animCont = animCont;
        _cambase = CamBase;

      

        _ajTransform = AJTransform;
        _rgdTransform = RGDTransform;

        _Rgd1 = one;
        _Rgd2 = two;


    }

    void SetForwardVector(Vector3 from, Vector3 to)
    {
        Vector3 From_ridYvalue = new Vector3(from.x, 0, from.z);
        Vector3 To_ridYvalue = new Vector3(to.x, 0, to.z);
  
        Forward = Quaternion.LookRotation(From_ridYvalue - To_ridYvalue);


    }

    public void OnEnter()
    {
        Debug.Log(_Rgd1);
        Debug.Log(_Rgd1.forward.y);
        isFacingUp = _Rgd1.forward.y > 0;
        SLerpStartTime = Time.time;
        if (isFacingUp)
        {
            Debug.Log("facingupfrom head to spine");
            SetForwardVector(_Rgd1.position, _Rgd2.position);

        }
        else
        {
            SetForwardVector(_Rgd2.position, _Rgd1.position);
    
        }

        _ajTransform.parent.rotation = Forward;

        RagdollSetter.PrepPlayer(_ajTransform, _rgdTransform);
        _animCont.SetTemplatePose(isFacingUp);
        SLerpSTransormstartTime = Time.time;
    }

    public void OnExit()
    {
        Ready = false;
    }

    public void OnUpdate()
    {

        if (Ready == false)
        {
            float timeSinceStarted = (Time.time - SLerpStartTime);
            float percentageComplete = (timeSinceStarted / SLerpDuration);

          

            _cambase.rotation = Quaternion.Slerp(_cambase.rotation, Forward, percentageComplete);
            //   Forward.x = 0;S


            float timeSinceTransformSlerpStarted = (Time.time - SLerpSTransormstartTime);
            float percentageCompleteOfTransformSlerp = (timeSinceTransformSlerpStarted / TransformsSLerpDuration);

           RagdollTransformData.SlerpTransforms(_ajTransform, _animCont._RagdollTemplateAnimator.transform, percentageCompleteOfTransformSlerp);

            if (percentageCompleteOfTransformSlerp > 1 && percentageComplete > 1)
            {
                Ready = true;
                return;

            }
        }


    }
}
