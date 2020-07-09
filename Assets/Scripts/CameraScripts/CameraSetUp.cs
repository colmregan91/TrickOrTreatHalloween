using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetUp : MonoBehaviour
{
    public static List<Camera> playerCameras = new List<Camera>();

    public static void AddCameraForPlayer(Camera playerCamera)
    {
        playerCameras.Add(playerCamera);
        InitializeCameras(playerCameras.Count);
    }
    public static void InitializeCameras(int numberofPlayers)
    {
        switch (numberofPlayers)
        {
            case 1:
                playerCameras[0].rect = new Rect(0, 0, 1, 1);
                playerCameras[0].depth = 0;

                break;
            case 2:
                playerCameras[0].rect = new Rect(0, 0.5f, 1, 1);
                playerCameras[0].depth = 0;
                playerCameras[1].rect = new Rect(0, -0.5f, 1, 1);
                playerCameras[1].depth = 1;

                break;
        }
    }

}
