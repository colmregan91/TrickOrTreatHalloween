using UnityEngine;

public class AnimStepper
{

    private readonly Animator _plyrAnim;
    int turnRightToHash;
    int turnLeftToHash;
    private playerEventHandler _playereventHandler;
    private IPlayer player;
    public AnimStepper(Animator playerAnim)
    {

        _plyrAnim = playerAnim;
        turnRightToHash = Animator.StringToHash("TurnRight");
        turnLeftToHash = Animator.StringToHash("TurnLeft");
        player = playerAnim.GetComponentInParent<IPlayer>();
        _playereventHandler = player.eventHandler;

        _playereventHandler.HandleTurning += Turn;
    }
    ~AnimStepper()
    {

        _playereventHandler.HandleTurning -= Turn;
    }

    public void Turn(int DotProduct)
    {
        if (DotProduct == 1)
        {
            _plyrAnim.SetTrigger(turnRightToHash);

        }
        else if (DotProduct == -1)
        {
            _plyrAnim.SetTrigger(turnLeftToHash);
        }

    }
}


