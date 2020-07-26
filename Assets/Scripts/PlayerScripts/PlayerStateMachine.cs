using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStateMachine : MonoBehaviour
{
    private StateMachine _PlayerStateMachine;
    private IPlayer _player;
    private IplayerInput playerInput;
    private Rigidbody rb;
    public string currentState;

    public event Action<Istate> HandleStateChange;
    private Idle idleState;
    private Running runState;
    private Turning turningState;
    private DodgeFromIdleState _dodgeFromIdleState;
    private playerInactive _playerinactiveState;
    private dodgeFromMoving _dodgeFromMoving;
    private RagdollstateMachine rgdStateMachine;
    private animationControl animCont;
    public OnRollFin DodgeStateMachineBehaviour { get; private set; }
    public OnTurningFinished TurnStateMachineBehaviour { get; private set; }
    bool isready;
    private void Awake()
    {
        rgdStateMachine = GetComponent<RagdollstateMachine>();
        animCont = GetComponentInChildren<animationControl>();
        _player = GetComponent<IPlayer>();
    }

    private IEnumerator Start()
    {
        isready = false;
        yield return new WaitUntil(() => _player.initialised == true);
        playerInput = _player.input;

        DodgeStateMachineBehaviour = animCont.onRollFin;
        TurnStateMachineBehaviour = animCont.onTurnFin;

        _PlayerStateMachine = new StateMachine();
        turningState = new Turning(_player);
        idleState = new Idle(_player, animCont);
        runState = new Running(_player, animCont);
        _dodgeFromIdleState = new DodgeFromIdleState(_player, animCont, DodgeStateMachineBehaviour);
        _playerinactiveState = new playerInactive(animCont._PlayerAnimator);
        _dodgeFromMoving = new dodgeFromMoving(_player, animCont, DodgeStateMachineBehaviour);
        initializeTransitions();
        _PlayerStateMachine.SetState(idleState);



        _PlayerStateMachine.HandleStateChange += state => HandleStateChange?.Invoke(state);

        isready = true;
    }

    void InitializeStates()
    {

    }
    void initializeTransitions()
    {
        _PlayerStateMachine.AddTransition(idleState, runState, () => _player.playerMover.isMoving);
        _PlayerStateMachine.AddTransition(runState, idleState, () => !_player.playerMover.isMoving);

        _PlayerStateMachine.AddTransition(idleState, turningState, () => _player.PlayerStep.isTurning);
        _PlayerStateMachine.AddTransition(turningState, idleState, () => turningState.TurnComplete && !animCont._PlayerAnimator.GetBool("isTurning"));

        _PlayerStateMachine.AddTransition(turningState, runState, () => _player.playerMover.isMoving);
        _PlayerStateMachine.AddTransition(turningState, _dodgeFromIdleState, () => playerInput.Dodge);
        _PlayerStateMachine.AddTransition(turningState, _dodgeFromMoving, () => playerInput.Dodge);


        _PlayerStateMachine.AddTransition(idleState, _dodgeFromIdleState, () => playerInput.Dodge);
        _PlayerStateMachine.AddTransition(runState, _dodgeFromMoving, () => playerInput.Dodge);

        _PlayerStateMachine.AddTransition(_dodgeFromIdleState, idleState, () => DodgeStateMachineBehaviour.isFinished && !_player.playerMover.isMoving);// STATE CCHECKER STATE FOR STAMINA, WILL BE SWAPPED
        _PlayerStateMachine.AddTransition(_dodgeFromMoving, idleState, () => DodgeStateMachineBehaviour.isFinished && !_player.playerMover.isMoving);

        _PlayerStateMachine.AddTransition(_dodgeFromMoving, runState, () => DodgeStateMachineBehaviour.isFinished && _player.playerMover.isMoving);
        _PlayerStateMachine.AddTransition(_dodgeFromIdleState, runState, () => DodgeStateMachineBehaviour.isFinished && _player.playerMover.isMoving);

        _PlayerStateMachine.addTransitionFromAnyState(_playerinactiveState, () => rgdStateMachine.goToRagdoll);
        _PlayerStateMachine.AddTransition(_playerinactiveState, idleState, () => rgdStateMachine.CheckforInactiveState());
    }

    void Update()
    {
        if (Pause.Active || isready == false) return;
        // Time.timeScale = 0.2f;
        _PlayerStateMachine.Tick();

        currentState = _PlayerStateMachine._currentState.ToString();
    }

}
public class playerInactive : Istate
{
    private Animator _playerAnim;

    public playerInactive(Animator playerAnim)
    {
        _playerAnim = playerAnim;
    }
    public void OnEnter()
    {

        //  _player.goToRagdoll = false;
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {

    }
}

