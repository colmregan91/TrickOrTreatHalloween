using UnityEngine;
using UnityEngine.Animations;

public class DodgeConstraints
{
    private AimConstraint _aimConstraint;
    private IplayerInput myPlayerInput;
    private bool Down_LerpWeight = false;
    private float timeOfDodgeStart;
    private float ConstraintLerpSpeed = 2;
    private float timeOfDodgeFinished;
    private bool Up_LerpWeight = false;

    public DodgeConstraints(AimConstraint aimConstraint, IPlayer player)
    {
        this._aimConstraint = aimConstraint;
        myPlayerInput = player.input;
        myPlayerInput.DodgePressed += LerpWeightDown;
    }
    ~DodgeConstraints()
    {
        myPlayerInput.DodgePressed -= LerpWeightDown;
    }
    public void ResetDodgeWeight()
    {
        Down_LerpWeight = false;
    //    timeOfDodgeFinished = Time.time;
    }
    void LerpWeightDown()
    {
        Down_LerpWeight = true;
        timeOfDodgeStart = Time.time;
    }
    public void LateTick()
    {
        if (Down_LerpWeight)
        {
            ControlDodgeConstraint();
        }
  
    }

    void ControlDodgeConstraint()
    {
     //   if (!_player.stateControl.ConstraintWeightUp)
     //   {
            float time = (Time.time - timeOfDodgeStart) * ConstraintLerpSpeed;
            float percentage = time / 1;
            _aimConstraint.weight = Mathf.Lerp(_aimConstraint.weight, 0, percentage);
      
    //    }
    }
}
