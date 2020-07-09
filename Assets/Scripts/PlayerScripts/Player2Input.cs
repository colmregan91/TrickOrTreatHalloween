using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player2Input : MonoBehaviour, IplayerInput
{
    public static IplayerInput instanceplyr2;
    public int playerNumber => 2;

    public static bool Initialisedplyr2;
    private void Awake()
    {
        if (Initialisedplyr2)
        {
            Destroy(gameObject);
            return;
        }
        Initialisedplyr2 = true;
        instanceplyr2 = this;
        InputManager.AddPlayer(instanceplyr2);
    }
    public float Vertical => UnityEngine.Input.GetAxis("Vertical_P2");

    public float Horizontal => UnityEngine.Input.GetAxis("Horizontal_P2");

    public Vector3 MoveVector => new Vector3(Horizontal, 0, Vertical);

    public float MouseX => UnityEngine.Input.GetAxis("Mouse X_P2") * 1.5f;

    public float MouseY => UnityEngine.Input.GetAxis("Mouse Y_P2") * 1.5f;

    public bool Dodge => UnityEngine.Input.GetButtonDown("Dodge_P2");

    public bool shoot => UnityEngine.Input.GetButtonDown("Shoot_P2");

    public bool AimingWeapon => UnityEngine.Input.GetButton("Aim_P2");

    public bool pause => UnityEngine.Input.GetButtonDown("pause_P2");
    public bool isTakingSweets => UnityEngine.Input.GetButton ("interact_P2");

    public bool isassigned { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public event Action DodgePressed;

    private void Update()
    {

        if (Dodge)
        {

            DodgePressed?.Invoke();

        }
        if (pause)
        {

            Pause.Active = !Pause.Active;
        }
        //if (shoot(AimingWeapon))
        //{
        //    //call shoot event??????????
        //}
    }


    // SEPARATE TICK METHODS FOR MENU NAVIGATION
}


