using System.Collections;
using UnityEngine;

public class DodgeController
{
    private Rigidbody PlayerRb;
    private float _DodgeForce;

    public DodgeController(Rigidbody _rb, float dodgeForce)
    {
        PlayerRb = _rb;
       _DodgeForce = dodgeForce;
    }
    public void DodgFromIdle (Vector3 rollDir)
    {
      PlayerRb.AddForce(rollDir.normalized * _DodgeForce, ForceMode.Impulse);

    }
    public void DodgFromMoving(Vector3 rollDir)
    {
        PlayerRb.AddRelativeForce(rollDir.normalized * _DodgeForce, ForceMode.Impulse);

    }
}



