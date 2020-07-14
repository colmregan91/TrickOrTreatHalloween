using UnityEngine;

public class Running : Istate
{
    private IPlayer _player;
    private animationControl _animCont;

    public Running (IPlayer player, animationControl animCont)
    {
        _player = player;
        _animCont = animCont;
    }

    public void OnEnter()
    {
        _animCont._PlayerAnimator.speed = 3;
    }

    public void OnExit()
    {
        _animCont._PlayerAnimator.speed = 1;
    }

    public void OnUpdate()
    {
        _animCont._animBlending.MoveBlendTick();
        _animCont._animBlending.SpeedAnimTick();
        _player.playerMover.Tick(_player.Speed);
        _animCont._animWeightCont.Tick();
        _player._playerRotation.RotateWhenMovingTick();
    //    _animCont._animWeightCont.ControlLegWeight(0, 0.1f);
    }
}

