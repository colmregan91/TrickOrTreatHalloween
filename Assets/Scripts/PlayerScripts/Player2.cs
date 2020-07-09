using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{ }
//    [SerializeField] private playerSettings PlayerSettingsRef;
//    public playerSettings PlayerSettings { get { return PlayerSettingsRef; } }
//    public Transform playerTransform { get; private set; }

//    public Mover playerMover { get; private set; }

//public PlayerStepper PlayerStep { get; private set; }

//    public StateMachine PlayerStateMachine { get; private set; }

//    public PlayerStateMachine playerstateMachine { get; private set; }

//    public inventory inventory { get; private set; }

//    public DodgeController DodgeCont { get; private set; }

//    public PlayerRotation _playerRotation { get; private set; }

//    public Rigidbody rb { get; private set; }

//    public Transform MyCamBase { get; private set; }

//    public Camera _PlayerCamera  { get; private set; }

//public Transform AimTarget { get; private set; }

//    public iRaiseEvents EventRaising { get; private set; }

//public CapsuleCollider MyCollider { get; private set; }

//    public animationControl animcont { get; private set; }

//    public IBind PlayerBinding { get; private set; }

//    public Purse purse { get; private set; }

//    private void OnDisable()
//    {
//        DeRegisterEvents();
//    }
//    private void Awake()
//    {
//        Initialize();
//    }
//    private void Start()
//    {
//        RegisterEVents();
//    }

//    public void DeRegisterEvents()
//    {
//        PlayerBinding.UnRegisterForPlayerToRGD(TakeControlAway);
//        PlayerBinding.UnRegisterForRGDtoPlayer(GiveControlBack);
//    }

//    public IplayerInput GetPlayerInput()
//    {
//        return InputManager.getAPlayer(1);
//    }

//    public void GiveControlBack(int? unusedParam)
//    {
//        MyCollider.enabled = true;
//        rb.isKinematic = false;
//    }

//    public void Initialize()
//    {
//        playerTransform = transform;
//        playerstateMachine = GetComponent<PlayerStateMachine>();
//        PlayerBinding = GetComponent<IBind>();
//        rb = GetComponent<Rigidbody>();
//        purse = GetComponent<Purse>();
//        DodgeCont = new DodgeController(rb, PlayerSettings.DodgeForce);
//        playerMover = new Mover(this);
//        _PlayerCamera = GetComponentInChildren<Camera>();
//        MyCamBase = _PlayerCamera.transform.parent;
//        AimTarget = _PlayerCamera.transform.Find("AimTarget");
//        PlayerStep = new PlayerStepper(this, AimTarget);
//        _playerRotation = new PlayerRotation(this, MyCamBase, AimTarget);
//        inventory = GetComponent<inventory>();
//    }

//    public void RegisterEVents()
//    {
//        PlayerBinding.RegisterForPlayerToRGD(TakeControlAway);
//        PlayerBinding.RegisterForRGDtoPlayer(GiveControlBack);
//    }

//    public void TakeControlAway(int? unusedParam)
//    {
//        MyCollider.enabled = false;
//        rb.isKinematic = true;
//    }

//}
