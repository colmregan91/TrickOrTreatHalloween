using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animInformationReceiver : MonoBehaviour
{
    public Animator AnimTemplate;
    private RagdollController _RagdollController;
    private Player _player;
    Animator PlayerAnim => GetComponent<Animator>();

    private void Awake()
    {
        _RagdollController = GetComponentInParent<RagdollController>();
        _player = GetComponentInParent<Player>();
    }

}
