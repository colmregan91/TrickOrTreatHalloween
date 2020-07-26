using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggTrajectoryControl : MonoBehaviour
{
    public Transform[] dots;
    private Vector3 ballPos;
    private float z1, y1;
    public float shotMultiplier;

    public float dotSeparation = 1f;
    public float dotShift = 0f;						//How far the first dot is from the "ball"

    public EggAimer aimer;

    private void Start()
    {
        ballPos = transform.position;
    }


    // Start is called before the first frame updateggg
    void CalculateEggArc()
    {
        // RaycastHit hit;

        for (int k = 0; k < dots.Length; k++)
        {
            //Each point of the trajectory will be given its position
            z1 = ballPos.z + aimer.ShotForce.z * Time.fixedDeltaTime * (dotSeparation * k + dotShift);    //X position for each point is found
            y1 = ballPos.y + aimer.ShotForce.y * Time.fixedDeltaTime * (dotSeparation * k + dotShift) - (-Physics2D.gravity.y / 2f * Time.fixedDeltaTime * Time.fixedDeltaTime * (dotSeparation * k + dotShift) * (dotSeparation * k + dotShift));    //Y position for each point is found
            dots[k].transform.position = transform.position + transform.TransformDirection(new Vector3(0, y1, z1));
            //  lr.SetPosition(k, dots[k].transform.position);
        }
    }

    private void Update()
    {
        CalculateEggArc();

    }
}
