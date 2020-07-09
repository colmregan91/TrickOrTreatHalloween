using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static List<IplayerInput> Players = new List<IplayerInput>();
    public static void AddPlayer(IplayerInput player)
    {

        Players.Add(player);
        Debug.Log("playeradded");
    }

    public static int GetPlayerCount()
    {
        return Players.Count;
    }

    public static List <IplayerInput> GetPlayerList()
    {
        return Players;
    }

    public static IplayerInput getAPlayer(int playerNumber)
    {
        return Players[playerNumber];
    }
}
