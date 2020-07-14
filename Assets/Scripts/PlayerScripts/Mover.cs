using System;
using UnityEngine;
using UnityEngine.AI;

public class Mover : IMover
{
    private readonly IPlayer _Player;
    private Transform _PlayerTransform;
    private IplayerInput myPlayerInput;
    public Vector3 LocalMovementVector;
    private float acceleration = 0.3f; // has to be higher than 0.2
    public bool isMoving => myPlayerInput.MoveVector != Vector3.zero;
    private Vector3 lerpedVector;
    public float currentXblendValue;
    public float currentYblendValue;


    public Vector3 _LerpedVector => lerpedVector;

    public Mover(IPlayer player)
    {
        _Player = player;
        _PlayerTransform = _Player.playerTransform;
   
        myPlayerInput = _Player.input;

    }

    void StopMovingForRagdoll()// not currently using this but will have to 
    {
    //    Playersettings.MoveVector = Vector3.zero;
        currentXblendValue = 0;
        currentYblendValue = 0;
        lerpedVector = Vector3.zero;
    }

    public void Tick(float Speed)
    {

        Vector3 movement = _PlayerTransform.rotation * myPlayerInput.MoveVector;

        LocalMovementVector = _PlayerTransform.InverseTransformVector(movement.normalized);

        float X = LocalMovementVector.x;
        float Z = LocalMovementVector.z;

        currentXblendValue = Mathf.Lerp(currentXblendValue, X, acceleration);

        currentYblendValue = Mathf.Lerp(currentYblendValue, Z, acceleration);

        currentXblendValue = Mathf.Clamp(currentXblendValue, -1f, 1f);
        currentYblendValue = Mathf.Clamp(currentYblendValue, -1f, 1f);


        lerpedVector = new Vector3(currentXblendValue, 0, currentYblendValue);

        float speedToGO = _Player.input.AimingWeapon ? (Speed / 2) * Time.deltaTime : Speed * Time.deltaTime;
        _PlayerTransform.Translate(lerpedVector * speedToGO);

    }
}

public interface IMover
{
    void Tick(float speed);
}