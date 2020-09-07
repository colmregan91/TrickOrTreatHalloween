using UnityEngine;
using UnityEngine.Animations;

public class AnimationBlending
{

    private readonly Animator _anim;
    private IplayerInput myPlayerInput;
    private camManager _camManager;
    private readonly IPlayer _player;
    private float curXblend;
    private float curZblend;
    private float curAimXblend;
    private float curAimYblend;
    private float BlendSpeedLerpToZero;
    private Vector3 moveVector;

    float blendLerpSpeed;
    public int AnimBlendX_ToHash { get; private set; }
    public int AnimBlendZ_ToHash { get; private set; }
    public int DodgeBlendX { get; private set; }
    public int DodgeBlendZ { get; private set; }
    public int RollTrigger_ToHash { get; private set; }
    public int aimBlendX_ToHash { get; private set; }
    public int aimBlendY_ToHash { get; private set; }
    public int SpeedAnim_ToHash { get; private set; }
    public int DodgeBlendX_ToHash { get; private set; }
    public int DodgeBlendZ_ToHash { get; private set; }

    private float animLerpSpeed = 0.5f;
    private float BlendSpeedLerp;


    public AnimationBlending(IPlayer player, Animator anim, camManager CamManager)
    {
        _player = player;
        _anim = anim;
        myPlayerInput = player.input;
        _camManager = CamManager;

        SetAnimHashIDs();
    }

    void SetAnimHashIDs()
    {
        AnimBlendX_ToHash = Animator.StringToHash("BlendX");
        AnimBlendZ_ToHash = Animator.StringToHash("BlendZ");
        //aimBlendX_ToHash = Animator.StringToHash("AimBlendX");
        //aimBlendY_ToHash = Animator.StringToHash("AimBlendY");
        SpeedAnim_ToHash = Animator.StringToHash("Speed");
        RollTrigger_ToHash = Animator.StringToHash("Roll");
        DodgeBlendX_ToHash = Animator.StringToHash("DodgeBlendX");
        DodgeBlendZ_ToHash = Animator.StringToHash("DodgeBlendZ");
    }



    public void MoveBlendTick()
    {
        moveVector = myPlayerInput.MoveVector;

        float X = moveVector.x;
        float Z = moveVector.z;


        curXblend = Mathf.Lerp(curXblend, X, 0.2f);
        curZblend = Mathf.Lerp(curZblend, Z, 0.2f);

        _anim.SetFloat(AnimBlendX_ToHash, curXblend);
        _anim.SetFloat(AnimBlendZ_ToHash, curZblend);

        ControlAimBlend();

        curXblend = Mathf.Clamp(curXblend, -1f, 1f);
        curZblend = Mathf.Clamp(curZblend, -1f, 1f);

    }

    public void resetSpeedAnimParam()
    {
        _anim.SetFloat(SpeedAnim_ToHash, 0);
    }

    public void SpeedAnimTick()
    {
        var cur = _anim.GetFloat(SpeedAnim_ToHash);
        cur = Mathf.Lerp(cur, _player.playerMover._LerpedVector.magnitude, 0.3f);


        _anim.SetFloat(SpeedAnim_ToHash, cur); 
    }

    public void SetDodgeBlendParamsFromMoving(Vector3 rollDIr)
    {

        _anim.SetFloat(DodgeBlendX_ToHash, rollDIr.normalized.x);
        _anim.SetFloat(DodgeBlendZ_ToHash, rollDIr.normalized.z);
        _anim.SetTrigger(RollTrigger_ToHash);
    }
    public void SetDodgeBlendParamsFromIdle()
    {

        _anim.SetFloat(AnimBlendX_ToHash, 0);
        _anim.SetFloat(AnimBlendZ_ToHash, 1);
        _anim.SetTrigger(RollTrigger_ToHash);
    }


    void ControlAimBlend()
    {
        _anim.SetBool("isAimingORwalking", _player.input.AimingWeapon);
        //    _anim.SetFloat(aimBlendX_ToHash, 0);
        //    _anim.SetFloat(aimBlendY_ToHash, 1);
        //    return;
        //}


        //float CamBlendX = _camManager.CamCont._tiltX / 100;
        //float CamBlendY = _camManager.CamCont._tiltY / 50;

        //curAimXblend = Mathf.Lerp(curAimXblend, CamBlendX, 0.1f);
        //curAimYblend = Mathf.Lerp(curAimYblend, CamBlendY, 0.1f);

        //curAimXblend = Mathf.Clamp(CamBlendX, -1f, 1f);
        //curAimYblend = Mathf.Clamp(CamBlendY, -1f, 1f);

        //_anim.SetFloat(aimBlendY_ToHash, -curAimYblend);
        //_anim.SetFloat(aimBlendX_ToHash, curAimXblend);
        //float mouseRotationY = myPlayerInput.MouseY * RotationAimSpeed;
        //_tiltY = Mathf.Clamp(_tiltY - mouseRotationY, -40f, 40f);
        //_anim.SetFloat(aimBlendX, -curXblend);
        //_anim.SetFloat(aimBlendY, -_tiltY / 40);
    }



}

//else
//{
//    Vector3 moveDir = AimConstraintTransform.up;
//    Vector3 keepOnGround = new Vector3(moveDir.x, 0, moveDir.z);
//    Vector3 normVec = keepOnGround.normalized;
//    Vector3 transdir = _player.transform.InverseTransformDirection(normVec);
//    _anim.SetFloat(DodgeBlendX, transdir.x);
//    _anim.SetFloat(DodgeBlendZ, transdir.z);


//   }




