using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class playerManager : MonoBehaviour
{
    private static playerController[] players;
    void Awake()
    {
        players = GetComponentsInChildren<playerController>();

        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
        GameStateMachine.Instance.HandleAddingPlayersToGame += AddPlayerToGame;
        GameStateMachine.Instance.HandleBeginGame += SpawnPLayerCharacters;
    }
    private void OnDisable()
    {
        GameStateMachine.Instance.HandleAddingPlayersToGame -= AddPlayerToGame;
        GameStateMachine.Instance.HandleBeginGame -= SpawnPLayerCharacters;
    }

    public void AddPlayerToGame(IplayerInput playerinput)
    {
       
        var firstUnassignedPlayer = players.FirstOrDefault(T => !T.hasController);
        firstUnassignedPlayer.InitializePlayer(playerinput);

    }

    public static void SpawnPLayerCharacters()
    {
        foreach (playerController player in players)
        {
            if (player.hasController && player.character != null)
            {
                player.SpawnCharacter();
            }
        }
    }
}
