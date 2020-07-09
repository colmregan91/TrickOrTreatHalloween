using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AddressableAssets;

public class playerSetup : MonoBehaviour
{
    private void Start()
    {
        playerManager.SpawnPLayerCharacters();
    }
    //[SerializeField] private AssetReference[] PlayerPrefabs;

    //public Transform player1_startPos;
    //public Transform player2_startPos;
    //private Vector3[] startingPositions;
    //void Awake()
    //{
    //    startingPositions = new Vector3[] { player1_startPos.position, player2_startPos.position };
    //}
    //private IEnumerator Start ()
    //{
    //    int PlayersThisGame = InputManager.GetPlayerCount();

    //    int assigner = 0;
    //    for (int i = 0; i < PlayersThisGame; i++)
    //    {
    //        var operation = PlayerPrefabs[i].InstantiateAsync();
    //        yield return operation;
    //        operation.Result.transform.position = startingPositions[assigner];
    //        assigner++;
    //    }

    //    yield return CameraSetUp.playerCameras.Count == PlayersThisGame;
    //    CameraSetUp.InitializeCameras(PlayersThisGame);

    //}

}
