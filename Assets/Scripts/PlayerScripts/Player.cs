using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Player : MonoBehaviour, IPlayer
{

    public Mover playerMover { get; private set; }
    public Transform playerTransform { get; private set; }
    public PlayerStepper PlayerStep { get; private set; }
    public StateMachine PlayerStateMachine { get; private set; }
    public inventory inventory { get; private set; }
    public DodgeController DodgeCont { get; private set; }
    public PlayerRotation _playerRotation { get; private set; }
    public Rigidbody rb { get; private set; }
    public camManager CamManager { get; private set; }
    public Camera _PlayerCamera { get; private set; }
    public Transform AimTarget { get; private set; }
    public Collider MyCollider { get; private set; }
    public animationControl animcont { get; private set; }
    public PlayerStateMachine playerstateMachine { get; private set; }
    public playerEventHandler eventHandler { get; private set; }
    public Purse purse { get; private set; }
    public bool initialised { get; private set; }

    public IplayerInput input { get; private set; }

    public float Speed => 5;

    public float DodgeForce => 40;

    public void SetController(IplayerInput _input)
    {
        input = _input;
        Initialize();
    }

    private IEnumerator Start()
    {
        initialised = false;
        yield return new WaitUntil(() => input != null);
        Initialize();
    }


    public void Initialize()
    {
        eventHandler = GetComponent<playerEventHandler>();
        CamManager = GetComponentInChildren<camManager>();
        animcont = GetComponentInChildren<animationControl>();

        AimTarget = CamManager.aimTarget;
        _PlayerCamera = CamManager.PlayerCam;
        playerTransform = transform;
        playerstateMachine = GetComponent<PlayerStateMachine>();
        rb = GetComponent<Rigidbody>();
        purse = GetComponent<Purse>();
        DodgeCont = new DodgeController(rb, DodgeForce);
        playerMover = new Mover(this);
        PlayerStep = new PlayerStepper(this, AimTarget);
        _playerRotation = new PlayerRotation(this, CamManager.transform, AimTarget);
        inventory = GetComponent<inventory>();
        MyCollider = GetComponent<Collider>();

        RegisterEVents();
        animcont.Initialize();

        initialised = true;
    }
    public void TakeControlAway()
    {
        MyCollider.enabled = false;
        rb.isKinematic = true;
        // goToRagdoll = true;
    }
    public void GiveControlBack()
    {
        //   goToRagdoll = false;
        MyCollider.enabled = true;
        rb.isKinematic = false;
    }
    private void OnDisable()
    {
        initialised = false;
        DeRegisterEvents();
    }
    public void DeRegisterEvents()
    {
        eventHandler.playertoRgdEvent -= TakeControlAway;
        eventHandler.RgdtoPlayerEvent -= GiveControlBack;
    }
    public void RegisterEVents()
    {
        eventHandler.playertoRgdEvent += TakeControlAway;
        eventHandler.playertoRgdEvent += GiveControlBack;
    }
}





