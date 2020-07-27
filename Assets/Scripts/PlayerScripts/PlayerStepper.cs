
using UnityEngine;
using System;
public class PlayerStepper
{
    private readonly IPlayer _player;
    private readonly Transform _aimTarget;

    private readonly animationControl _plyrAnim;
    private float TurnThreshold = 60;
    private playerEventHandler PlayerEventHandler;
    PlayerStateMachine playerStateMachine;
    public bool isTurning;

    float angle;
    public PlayerStepper(IPlayer player, Transform aimtarget)
    {
        _player = player;
        _aimTarget = aimtarget;
        PlayerEventHandler = _player.eventHandler;

    }


    public int CalculateAngleDirection()
    {
        Transform playerTransform = _player.playerTransform;
        Vector3 AimTarFwd = _aimTarget.forward;

        Vector3 heading = Vector3.Cross(playerTransform.forward, AimTarFwd);
        float dir = Vector3.Dot(heading, playerTransform.up);


        if (dir > 0f)
        {

            return 1;
        }
        else if (dir < 0)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
    float GetAngleBetweenPlayerandTarget()
    {
        float ang = Vector3.Angle(_player.playerTransform.forward, _aimTarget.forward);
        return ang;
    }

    public bool CheckTurning()
    {
        Debug.Log(angle > TurnThreshold);
        return angle > TurnThreshold;
    }

    public void Tick()
    {



        angle = GetAngleBetweenPlayerandTarget();

        if (CheckTurning())
        {
            int Dot = CalculateAngleDirection();
            PlayerEventHandler.RaiseHandleTurning(Dot);

        }

    }
}
