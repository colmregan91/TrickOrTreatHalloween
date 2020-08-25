using UnityEngine;
using System.Collections.Generic;
public class EggProjectile : PooledMonoBehavior
{
    public Rigidbody rb;
    public float moveSpeed = 3;
    int currentDot;
    private Vector3 startPos;
    private bool hasBegun;
    private List<Vector3> pathPoints = new List<Vector3>();

    public float Timer { get; private set; }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    gameObject.SetActive(false);
    //}

    protected override void OnDisable()
    {
        rb.useGravity = false;
        base.OnDisable();
    }

    private void Start()
    {
        startPos = transform.position;
    }

    public void BeginLaunch(Transform[] dots, float force)
    {
        foreach (var point in dots)
        {
            pathPoints.Add(point.transform.position);
        }
        hasBegun = true;
        moveSpeed = force;
    }

    private void Update()
    {
        if (!hasBegun) return;
        Timer += Time.deltaTime * moveSpeed;

        if (transform.position != pathPoints[currentDot])
        {
            transform.position = Vector3.Lerp(startPos, pathPoints[currentDot], Timer);

        }
        else if (currentDot < pathPoints.Count - 1)
        {
            currentDot++;
            checkDot();
        }
    }
    void checkDot()
    {
        startPos = transform.position;
        Timer = 0;
    }
}
