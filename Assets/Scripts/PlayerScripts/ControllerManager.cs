using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public IplayerInput[] Controllers;

    private void Awake()
    {
        Controllers = GetComponentsInChildren<IplayerInput>();
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        foreach (IplayerInput cont in Controllers)
        {
            if (!cont.isassigned && cont.Dodge)
            {

                assignController(cont);
                GameStateMachine.Instance.AddPlayer(cont);
            }
        }
    }

    private void assignController(IplayerInput cont)
    {
        cont.isassigned = true;
    }
}
