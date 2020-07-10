using UnityEngine;

public class Idle : Istate
{
    private IPlayer _player;
    private animationControl _animCont;
    private PlayerStepper playerStepper;
    public Idle(IPlayer player, animationControl animCont)
    {
        _player = player;
        _animCont = animCont;
        playerStepper = _player.PlayerStep;
    }
    public void OnEnter()
    {
        playerStepper.isTurning = false;
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
     //   _animCont._animWeightCont.ControlLegWeight(1, 0.1f);
        playerStepper.Tick();
        _animCont._animBlending.MoveBlendTick();
        _animCont._animBlending.SpeedAnimTick();
     //   _animCont._animWeightCont.Tick();
        _player.playerMover.Tick(_player.Speed);

    }
}

