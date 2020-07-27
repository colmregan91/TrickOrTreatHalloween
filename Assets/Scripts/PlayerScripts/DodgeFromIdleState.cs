using UnityEngine;

public class DodgeFromIdleState : Istate
{
    protected IPlayer _player;
    protected OnRollFin _OnRollFin;
    protected animationControl _animCont;
  //  protected IKcontrol ikCont;
    private Quaternion TargetQuaternion;
    private OnRollFin onrollFin;

    public DodgeFromIdleState(IPlayer player, animationControl animCont, OnRollFin onRollFin)
    {
        _player = player;
        _OnRollFin = onRollFin;
        _animCont = animCont;

        //ikCont = animCont.GetComponentInParent<IKcontrol>();
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
        //ikCont.GiveCOntrolToIK(false);
        _OnRollFin.isFinished = false;
    }

    public void OnExit()
    {

        _OnRollFin.isFinished = true;
        _OnRollFin.TimeToGivePlayerBackInput = true;
    //    _animCont._animWeightCont.ControlLegWeight(1, 1);
    }

    public void OnUpdate()
    {
     //   _animCont._animWeightCont.ControlLegWeight(0, 1);
        if (_OnRollFin.TimeToGivePlayerBackInput)
        {
            _player.playerMover.Tick(_player.Speed);
              _animCont._animBlending.MoveBlendTick();
            _animCont._animBlending.SpeedAnimTick();

        }
    }
}

