using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class animationControl : MonoBehaviour
{

    private IPlayer player => GetComponentInParent<IPlayer>();
    private AimConstraint aimConstraint => GetComponentInChildren<AimConstraint>();
    private Animator PlayerAnimator;
    public PlayerStateMachine _plyrstateMachine { get; private set; }
    public OnRollFin onRollFin { get; private set; }
    public OnTurningFinished onTurnFin { get; private set; }
    public AnimationBlending _animBlending { get; private set; }

    private AnimStepper _animStepper;
    public AnimWeightControl _animWeightCont { get; private set; }

    public Animator _RagdollTemplateAnimator;

    private int RollTriggerID;
    public Animator _PlayerAnimator => PlayerAnimator;
    public int TurnID { get; private set; }
    public bool hasControlOverAnim = true;
    public AnimStepper animStepper => _animStepper;
    void SetAnImHashIDs() // UPDATE FOR ALL STRING REFS IN THIS SCR
    {
        RollTriggerID = Animator.StringToHash("Roll");
        TurnID = Animator.StringToHash("isTurning");
    }

    public void Initialize()
    {
        PlayerAnimator = GetComponentInParent<Animator>();
        onRollFin = _PlayerAnimator.GetBehaviour<OnRollFin>();
        onTurnFin = _PlayerAnimator.GetBehaviour<OnTurningFinished>();
        _animStepper = new AnimStepper(_PlayerAnimator);
        _animBlending = new AnimationBlending(player, _PlayerAnimator, player.CamManager);
        _plyrstateMachine = GetComponentInParent<PlayerStateMachine>();
        _animWeightCont = new AnimWeightControl(_PlayerAnimator, player);

        SetAnImHashIDs();
        _PlayerAnimator.keepAnimatorControllerStateOnDisable = true;
    }

    private void OnDisable()
    {
        Debug.Log("click Here");
       // _PlayerAnimator.SetFloat("Speed", 0f); // RID THIS IF CAN, CHECK ON RGD DAY
    }


    public void setAnimator(bool value)
    {
        _PlayerAnimator.enabled = value;
    }
    public void PlayAnim(string animtoPlay)
    {
        _PlayerAnimator.Play(animtoPlay);
    }
    public void SetTemplatePose(bool isfacingupwards)
    {
        if (isfacingupwards)
        {
            _RagdollTemplateAnimator.SetBool("Back", true);
            _RagdollTemplateAnimator.SetBool("Front", false);
            _RagdollTemplateAnimator.Play("GetUpBack");

        }
        else
        {
            _RagdollTemplateAnimator.SetBool("Front", true);
            _RagdollTemplateAnimator.SetBool("Back", false);
            _RagdollTemplateAnimator.Play("GetUpFront");

        }

    }

    
}

