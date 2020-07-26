using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Controller : MonoBehaviour, IplayerInput
{
    public bool isassigned { get; set; }
    public float Vertical => Input.GetAxis("Vertical");
    public float Horizontal => Input.GetAxis("Horizontal");

    public Vector3 MoveVector => new Vector3(Horizontal, 0, Vertical);
    public float MouseX => Input.GetAxis("Ranalog X") + Input.GetAxis("Mouse X");

    public bool isTakingSweets => Input.GetKey(KeyCode.Joystick1Button3) || Input.GetKey(KeyCode.I);
    public float MouseY => Input.GetAxis("Ranalog Y") + Input.GetAxis("Mouse Y");
    public bool Dodge => Input.GetKey(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.B);

    public bool AimingWeapon => Input.GetKey(KeyCode.Joystick1Button6) || Input.GetKey(KeyCode.Mouse1);

    public bool selectSlot1 => Input.GetKeyDown(KeyCode.Alpha1) || UnityEngine.Input.GetKeyDown(KeyCode.Joystick1Button9);
    public bool selectSlot2 => Input.GetKeyDown(KeyCode.Alpha2)  || UnityEngine.Input.GetKeyDown(KeyCode.Joystick1Button10);

    public bool shoot => Input.GetKeyUp(KeyCode.Joystick1Button7) || Input.GetKeyUp(KeyCode.Mouse0);

    public bool pause => Input.GetKeyDown(KeyCode.Joystick1Button9) || Input.GetKeyDown(KeyCode.Escape);



    public event Action DodgePressed;
}


//public int Index { get; set; }

//public bool anyButtonDown()
//{
//    return X_Button();
//}

//public void SetIndex(int index)
//{
//    Index = index;
//}

//public Vector3 getDirection()
//{
//    return new Vector3(Horizontal(), 0, Vertical()).normalized;
//}
//public bool X_Button()
//{
//    bool X_BUtton = Input.GetKeyUp(KeyCode.Joystick1Button1) || Input.GetKeyUp(KeyCode.K);
//    return X_BUtton;
//}
//public bool Hold_X_Button()
//{
//    bool XHold = Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.K);

//    return XHold;
//}
//public bool Circle_Button()
//{
//    bool Circle = Input.GetKeyUp(KeyCode.Joystick1Button2) || Input.GetKeyUp(KeyCode.L);
//    return Circle;
//}
//public bool Hold_Circle_Button()
//{
//    bool CircleHold = Input.GetKey(KeyCode.Joystick1Button2) || Input.GetKey(KeyCode.K);
//    return CircleHold;
//}
//public bool Square_Button()
//{
//    bool Square = Input.GetKeyUp(KeyCode.Joystick1Button3) || Input.GetKeyUp(KeyCode.J);
//    return Square;
//}
//public bool Start_Button()
//{
//    bool StartBut = Input.GetKeyDown(KeyCode.Joystick1Button9) || Input.GetKeyDown(KeyCode.Escape);
//    return StartBut;
//}


//public float Horizontal()
//{
//    float horizontal = Input.GetAxis("Horizontal");
//    return horizontal;
//}

//public float Vertical()
//{
//    float vertical = Input.GetAxis("Vertical");
//    return vertical;
//}