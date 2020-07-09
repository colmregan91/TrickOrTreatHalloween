using UnityEngine;

public class DodgeFromIdleState : Istate
{
    protected IPlayer _player;
    protected OnRollFin _OnRollFin;
    protected animationControl _animCont;
    private Quaternion TargetQuaternion;
    private OnRollFin onrollFin;

    public DodgeFromIdleState(IPlayer player, animationControl animCont, OnRollFin onRollFin)
    {
        _player = player;
        _OnRollFin = onRollFin;
        _animCont = animCont;
    }

    public virtual void OnEnter()
    {
        _animCont._animBlending.resetSpeedAnimParam();
        _animCont._animBlending.SetDodgeBlendParamsFromIdle();
        TargetQuaternion = _player._playerRotation.getRotationTarget();
        _player._playerRotation.SetRotationFromIdleDodge(TargetQuaternion);

        Vector3 pos = _player.playerTransform.forward.normalized;
        Vector3 rollDir = new Vector3(pos.x, 0, pos.z);

        _player.DodgeCont.DodgFromIdle(rollDir);

    }

    public void OnExit()
    {
        _OnRollFin.isFinished = false;
        _OnRollFin.TimeToGivePlayerBackInput = false;
        _animCont._animWeightCont.ControlLegWeight(1, 1);
    }

    public void OnUpdate()
    {
        _animCont._animWeightCont.ControlLegWeight(0, 1);
        if (_OnRollFin.TimeToGivePlayerBackInput)
        {
            _player.playerMover.Tick(_player.Speed);
              _animCont._animBlending.MoveBlendTick();
            _animCont._animBlending.SpeedAnimTick();

        }
    }
}

