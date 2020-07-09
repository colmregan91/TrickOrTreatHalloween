using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class playerController : MonoBehaviour
{
    public event Action OnPlayerChanged;

    public IplayerInput controller;

    public Player character;

    public bool hasController { get { return controller != null; } }


    public void InitializePlayer(IplayerInput cont)
    {
        
        this.controller = cont;
        //   playerUI.HandlePlayerInitialized();

    }

    public void SpawnCharacter()
    {

        var playerCharacter = Instantiate(character, Vector3.zero, Quaternion.identity);
        playerCharacter.SetController(controller);
    }
}