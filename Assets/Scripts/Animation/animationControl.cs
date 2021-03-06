﻿using System;
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

        // used in elsewhere also
    }



    public void setAnimator(bool value)
    {
   //     _PlayerAnimator.ResetTrigger("Roll");
        _PlayerAnimator.enabled = value;

        if (value == true)
        {
            Debug.Log("turned on now");
        }
    }
    public void PlayAnim(string animtoPlay)
    {
        _PlayerAnimator.Play(animtoPlay);

    }
    public void SetTemplatePose(bool isfacingupwards)
    {
        if (!isfacingupwards)
        {
            Debug.Log("facedown");
            _RagdollTemplateAnimator.SetBool("Back", true);
            _RagdollTemplateAnimator.SetBool("Front", false);
            _RagdollTemplateAnimator.Play("faceDwn_GetUp");

        }
        else
        {
            Debug.Log("faceup");
            _RagdollTemplateAnimator.SetBool("Front", true);
            _RagdollTemplateAnimator.SetBool("Back", false);
            _RagdollTemplateAnimator.Play("faceUp_Getting Up");

        }

    }


}

