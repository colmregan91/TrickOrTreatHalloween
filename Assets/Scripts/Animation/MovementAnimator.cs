//using UnityEngine;

//public class MovementAnimator
//{
//    private readonly Animator _anim;
//    private readonly Player _player;
//    private float AnimSpeedLerp;
//    private float LerpSpeed = 0.5f;
//    private float animSpeed;
//    private float AnimSpeedLerpToZero;
//    private float MaxAnimSpeed = 3.2f;
//    private float MinAnimSpeed = 0.5f;

//    int AnimSpeed;
//    int isMoving;

//    public MovementAnimator(Player player, Animator anim)
//    {
//        _player = player;
//        _anim = anim;

//        AnimSpeed = Animator.StringToHash("animSpeed");
//        isMoving = Animator.StringToHash("isMoving");
//    }

//    public void Tick()
//    {

//        //if (_player.playerMover._MoveVector != Vector3.zero) 
//        //{

//        //    AnimSpeedLerp += (LerpSpeed * Time.deltaTime);
//        //    animSpeed = Mathf.Lerp(animSpeed, MaxAnimSpeed, AnimSpeedLerp);
//        //    AnimSpeedLerpToZero = 0;
//        //}
//        //else
//        //{

//        //    if (AnimSpeedLerpToZero < 1)
//        //    {
//        //        AnimSpeedLerpToZero += LerpSpeed * Time.deltaTime;
//        //    }
//        //    else
//        //    {
//        //        AnimSpeedLerpToZero = 1;
//        //    }
//        //    AnimSpeedLerp = 0;
//        //    animSpeed = Mathf.Lerp(animSpeed, MinAnimSpeed, AnimSpeedLerpToZero);
         

//        //}
//        animSpeed = Mathf.Clamp(animSpeed, MinAnimSpeed, MaxAnimSpeed);
//        _anim.SetFloat(AnimSpeed, animSpeed);
    

//    }

//}
