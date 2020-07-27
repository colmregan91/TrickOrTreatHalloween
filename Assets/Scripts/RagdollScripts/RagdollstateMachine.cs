using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RagdollstateMachine : MonoBehaviour
{

    [SerializeField] private Transform AJtransform;
    [SerializeField] private Transform RGDtransform;

    private StateMachine _RagdollStateMachine;
    private RagdollInactive _ragdollInactiveState;
    private OnRagdoll _ragdollState;
    private CorrectingCameraPositionAndLerpingTransforms _CorrecingCamPos;

    public PlayerGetUp _playerGetUp;
    private IPlayer player => GetComponent<IPlayer>();
    private playerEventHandler playerEvHandler => GetComponent<playerEventHandler>();
    private animationControl AnimCont => GetComponentInChildren<animationControl>();
    public event Action<Istate> HandleStateChanged;
    public bool goToRagdoll;
    bool isReady;

    public Transform RGspine;
    public Transform RGhead;
    IEnumerator Start()
    {
        isReady = false;
           yield return new WaitUntil(() => player.initialised);
        
        playerEvHandler.playertoRgdEvent += setRagdollBool;

        _RagdollStateMachine = new StateMachine();
        _RagdollStateMachine.HandleStateChange += state => HandleStateChanged?.Invoke(state);

        _ragdollInactiveState = new RagdollInactive(AnimCont);

        _ragdollState = new OnRagdoll(RGDtransform, AJtransform, RGspine);

        _CorrecingCamPos = new CorrectingCameraPositionAndLerpingTransforms(player.CamManager.transform, AnimCont, AJtransform, RGDtransform, RGspine, RGhead);

        _playerGetUp = new PlayerGetUp(AnimCont);

        _RagdollStateMachine.SetState(_ragdollInactiveState);

        InitializeStateTransitions();

        isReady = true;
    }

    private void OnDisable()
    {
        playerEvHandler.playertoRgdEvent -= setRagdollBool;
        _RagdollStateMachine.HandleStateChange -= state => HandleStateChanged?.Invoke(state);

    }

    public bool CheckforInactiveState()
    {

        if (_RagdollStateMachine._currentState is RagdollInactive)
        {
            Debug.Log("raisedf");
         
            playerEvHandler.RaiseRgdtoPlayerEvent();
            return true;
        }
        else
        {
            return false;
        }
    }

    void setRagdollBool()
    {
        goToRagdoll = true;
        Invoke("f", 1f);
    }
    private void f()
    {
        goToRagdoll = false;
    }

    void InitializeStateTransitions()
    {
        _RagdollStateMachine.AddTransition(_ragdollInactiveState, _ragdollState, () => goToRagdoll);
        _RagdollStateMachine.AddTransition(_ragdollState, _CorrecingCamPos, () => _ragdollState.continuetoNextState);
        _RagdollStateMachine.AddTransition(_CorrecingCamPos, _playerGetUp, () => _CorrecingCamPos.Ready);
        _RagdollStateMachine.AddTransition(_playerGetUp, _ragdollInactiveState, () => _playerGetUp.SetRagdollInactive);
    }
    private void Update()
    {
        if (Pause.Active || !isReady) return;

        _RagdollStateMachine.Tick();

    }
}
