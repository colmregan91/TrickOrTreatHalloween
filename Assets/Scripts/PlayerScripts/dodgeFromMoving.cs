using UnityEngine;

public class dodgeFromMoving : DodgeFromIdleState
{
    public dodgeFromMoving(IPlayer player, animationControl animCont, OnRollFin onRollFin) : base(player, animCont, onRollFin)
    {
        _player = player;
        _OnRollFin = onRollFin;
        _animCont = animCont;

   
    }

    public override void OnEnter()
    {
        _animCont._animBlending.resetSpeedAnimParam();
        _animCont._animBlending.SetDodgeBlendParamsFromMoving();
        Vector3 pos = _player.input.MoveVector;
        Vector3 rollDir = new Vector3(pos.x, 0, pos.z);

        _player.DodgeCont.DodgFromMoving(rollDir);
        _OnRollFin.isFinished = false;
        //  ikCont.GiveCOntrolToIK(false);
    }
}

