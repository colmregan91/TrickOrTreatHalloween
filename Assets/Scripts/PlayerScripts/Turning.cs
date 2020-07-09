using UnityEngine;

public class Turning : Istate
{
    private IPlayer _player;
    private Quaternion targetQuaternion;
    private float turnDuration = 0.5f;
    public bool TurnComplete;
    private PlayerStepper playerstep;
    public float TurnStartTime { get; private set; }

    public Turning(IPlayer player)
    {
        _player = player;
        playerstep = _player.PlayerStep;
    }

    public void OnEnter()
    {
        TurnComplete = false;
        targetQuaternion = _player._playerRotation.getRotationTarget();
        TurnStartTime = Time.time;
    }

    public void OnExit() //  CONDITION WHEN PLAYER IS PERFECTLY ALIGNED, TURNING IS BUGGING OUT
    {
    //    playerstep.isTurning = false;
        TurnComplete = false;
        playerstep.isTurning = false;
    }

    public void OnUpdate()
    {

        float TimeSinceStartedTurning = (Time.time - TurnStartTime);
        float percentageComplete = (TimeSinceStartedTurning / turnDuration);

        float g = _player.playerTransform.eulerAngles.magnitude;
        float b = targetQuaternion.eulerAngles.magnitude;

       // if (percentageComplete < 0.2f)
        //{
            targetQuaternion = _player._playerRotation.getRotationTarget();

       // }

        _player._playerRotation.RotateWhenStillTick(targetQuaternion, percentageComplete);

        if (Mathf.RoundToInt(g) == Mathf.RoundToInt(b))
        {
            TurnComplete = true;
        }

        _player.playerMover.Tick(_player.Speed);

    }
}

