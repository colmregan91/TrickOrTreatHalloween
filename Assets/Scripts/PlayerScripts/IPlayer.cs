using UnityEngine;

public interface IPlayer
{
    IplayerInput input
    {
        get;
    }
    void SetController(IplayerInput _input);

    Transform playerTransform { get; }

    Mover playerMover { get; }
    PlayerStepper PlayerStep { get; }
    StateMachine PlayerStateMachine { get; }
    inventory inventory { get; }
    DodgeController DodgeCont { get; }
    PlayerRotation _playerRotation { get; }
    Rigidbody rb { get; }
    camManager CamManager { get; }
    Camera _PlayerCamera { get; }
    Transform AimTarget { get; }
    Collider MyCollider { get; }
    //animationControl animcont { get; }
    PlayerStateMachine playerstateMachine { get; }
    playerEventHandler eventHandler { get; }
    Purse purse { get; }
    void Initialize();
    void TakeControlAway();
    void GiveControlBack();
    void RegisterEVents();
    void DeRegisterEvents();
    bool initialised
    {
        get;
    }

     float Speed { get; }
    float DodgeForce { get; }

}





