using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class projectile : PooledMonoBehavior
{
    [SerializeField] private float RangeInSeconds = 1;
    public float hitForce;
    public Rigidbody rb;
    [SerializeField] private GameObject explosion;
    public Collider col;
    public GameObject sparkles;
    public float shotTime;
    Transform parent;
    MeshRenderer meshrenderer => GetComponent<MeshRenderer>();
    Vector3 vel;
    private Vector3 explosionPos;

    void PrepDetonation()
    {
        rb.velocity = Vector3.zero;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        rb.isKinematic = true;
        meshrenderer.enabled = false;
        explosion.gameObject.SetActive(true);
        sparkles.SetActive(false);
        col.enabled = false;
        Invoke("turnoff", 2f);
    }

    private void Update()
    {
        if (Time.time >= shotTime + 0.7f)
        {
            manualExplode();
        }
    }

    private void OnEnable()
    {
        parent = transform.parent;
           shotTime = Time.time;
    }
    void ResetDetonation()
    {
        rb.velocity = Vector3.zero;
        rb.isKinematic = false;
        explosion.gameObject.SetActive(false);
        meshrenderer.enabled = true;
        sparkles.SetActive(true);
        col.enabled = true;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

    }

    void manualExplode()
    {
        explosionPos = transform.position;
        PrepDetonation();

        AddCollisionForce();
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerEventHandler eventHandler = collision.gameObject.GetComponent<playerEventHandler>();

        if (eventHandler != null)
        {
            eventHandler.RaiseplayertoRgdEvent();
            Invoke("AddCollisionForce", 0.01f);             // wont work very dodgy.  need to wait until ragdoll is confirmed active before detonate can be called
                                                            // NEED TO IMPLEMENT ITAKEHITS INTERFACE
        }
        PrepDetonation();

    }

    void AddCollisionForce()
    {

        Collider[] HitCols = Physics.OverlapSphere(transform.position, 1); // non alloc
        // WILL NEED TO CONVERT TO A LIST

        foreach (Collider hitCol in HitCols)
        {


            Rigidbody d = hitCol.GetComponent<Rigidbody>();
            if (d != null)
            {
                d.AddExplosionForce(hitForce, explosionPos, 1, 0.3f, ForceMode.Impulse);

            }
        }


    }

    void turnoff()
    {
        transform.SetParent(parent);
        gameObject.SetActive(false);
    }

    private new void OnDisable()
    {
        base.OnDisable();
        ResetDetonation();

    }
}
