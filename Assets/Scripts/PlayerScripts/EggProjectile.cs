using UnityEngine;
public class EggProjectile : PooledMonoBehavior
{
    public Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }

    protected override void OnDisable()
    {
        rb.useGravity = false;
        base.OnDisable();
    }
}
