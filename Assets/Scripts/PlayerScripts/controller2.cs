using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller2 : MonoBehaviour, IplayerInput
{
    public bool isassigned { get; set; }
    public float Vertical => UnityEngine.Input.GetAxis("Vertical_P2");
    public float Horizontal => UnityEngine.Input.GetAxis("Horizontal_P2");

    public Vector3 MoveVector => new Vector3(Horizontal, 0, Vertical);
    public float MouseX => UnityEngine.Input.GetAxis("Ranalog X_P2");

    public bool isTakingSweets => Input.GetKey(KeyCode.Joystick2Button3);
    public float MouseY => UnityEngine.Input.GetAxis("Ranalog Y_P2");
    public bool Dodge => Input.GetKey(KeyCode.Joystick2Button2);

    public bool AimingWeapon => Input.GetKey(KeyCode.Joystick2Button6);

    public bool selectSlot1 => UnityEngine.Input.GetKeyDown(KeyCode.Joystick2Button9);
    public bool selectSlot2 => UnityEngine.Input.GetKeyDown(KeyCode.Joystick2Button10);

    public bool shoot => Input.GetKeyUp(KeyCode.Joystick2Button7);

    public bool pause => Input.GetKeyDown(KeyCode.Joystick2Button9) || Input.GetKeyDown(KeyCode.Escape);

    public event Action DodgePressed;

}
