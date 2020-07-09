using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCollisions : MonoBehaviour
{
    public float minDistance = 0.5f;
    public float maxDistance = 5f;
    public Vector3 dollyDir;
    public float distance;

    //private myPlayerController PlayerControllerScr;
    private GameObject playerHolder;
    public Vector3 offset;


    private void Start()
    {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;

    }
    private void Update()
    {
        Vector3 desiredCamPos = transform.parent.TransformPoint(dollyDir * maxDistance);
        //Debug.DrawLine(transform.parent.position, desiredCamPos);
        RaycastHit hit;
        if (Physics.Linecast(transform.parent.position, desiredCamPos, out hit ))
        {
            
                // Debug.Log(hit.collider.gameObject.name);// THIS HITS THE PLANE FIX
                distance = Mathf.Clamp((hit.distance * 0.8f), minDistance, maxDistance);
            
        }
        else
        {
            distance = maxDistance;
        }


    }

}
