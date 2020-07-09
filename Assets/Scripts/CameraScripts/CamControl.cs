using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl
{

    public float _tiltY;
    public float _tiltX;
    private Camera _camera;
    private float mouseRotationY;
    private float mouseRotationX;
    public float RotationSpeed;
    public Transform cambase;
    private IplayerInput myPlayerInput;
    public bool cancontrol;

    public CamControl(Camera cam, Transform camBase, IplayerInput input, float rotSpeed)
    {
        _camera = cam;
        cambase = camBase;
        myPlayerInput = input;
        RotationSpeed = rotSpeed;
        cancontrol = true;
    }

    public void Tick()
    {

        if (cancontrol)
        {
            mouseRotationY = myPlayerInput.MouseY * RotationSpeed;
            mouseRotationX = myPlayerInput.MouseX * RotationSpeed;


            _tiltY = Mathf.Clamp(_tiltY - mouseRotationY, -40f, 40f);
            _tiltX += mouseRotationX;
            Vector3 rot = new Vector3(_tiltY, _tiltX, 0);
            cambase.rotation = Quaternion.Euler(rot);
        }
        else
        {

            _tiltY = cambase.eulerAngles.x;
            _tiltX = cambase.eulerAngles.y;
        }

    }


}

