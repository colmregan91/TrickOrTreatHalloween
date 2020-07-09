using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : PooledMonoBehavior
{
    [SerializeField] private int CandyValue;
    private Vector3 RandomTargetLerpPos;
    private Vector3 Distance;
    public float rotateSpeed;
    private Rigidbody rb;
    private void OnTriggerEnter(Collider other)
    {
        var Purse = other.GetComponent<Purse>();

        if (Purse != null)
        {
            if (Purse.CanTake)
            {
                Purse.AddToPurse(CandyValue);
                gameObject.SetActive(false);
            }

        }
    }
    private void OnEnable()
    {
        // base.OnEnable();
        Vector3 pos = Random.insideUnitSphere;
        Vector3 addedPos = transform.localPosition + pos.normalized;
        RandomTargetLerpPos = new Vector3(addedPos.x, 1, addedPos.y);
        Distance = transform.position - RandomTargetLerpPos;
    }
    private void Update()
    {
        if (Distance.magnitude < 1)
        {
            return;
        }

        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        transform.position = Vector3.Lerp(transform.position, RandomTargetLerpPos, 0.2f);
    }
}
