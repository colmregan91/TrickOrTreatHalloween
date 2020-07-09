using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
[System.Serializable]

public class FireworkObject : ScriptableObject, Ishootable
{
    public PooledMonoBehavior myProjectile;
    public float CoolDownTime;
    public int BulletsPerRound;
    public float ProjectileForce;
    public float FireRate;
    public int ShotsFired = 0;
    public bool RoundFinished;
    public float aimRange;
    public void SetMyPool()
    {
        Pool.GetPool(myProjectile);
    }

    public void Shoot(Vector3 dir, Vector3 Shotpos)
    {
        if (RoundFinished)
        {
            ShotsFired = 0;
            RoundFinished = false;
        }

        var projectile = myProjectile.Get<projectile>(Shotpos, Quaternion.identity);
        projectile.transform.SetParent(null);

        projectile.rb.AddForce(dir * ProjectileForce, ForceMode.Impulse);

        ShotsFired++;
        if (ShotsFired == BulletsPerRound)
        {

            RoundFinished = true;
        }

    }
}



//public float range;
//public float speed;
//public float hitForce;
//public WaitForSeconds fireRate;
//public float fireRateInv;
//public float CoolDownTime;
//public int BulletsPerRound;
//public Material FireWorkMaterial; // used by changefirework mesh prefab
//public Mesh FireworkMesh; // used by changefirework mesh prefab
//public string description; // for the shop
//public string WeaponName; // for the shop
//public int cost; // for the shop


//public projectile myProjectilePrefab;
////  public Pool myBulletPool;




//public void Shoot(Vector3 Direction, Pool pool)
//{
//    Debug.Log("firworkObj shooting from " + pool.name);

//    var projectile = myProjectilePrefab.Get<projectile>("bullet", pool);
//    //  projectile.transform.LookAt(projectile.transform.position + Direction);
//    if (projectile.transform.parent == null)
//    {
//        projectile.hitForce = hitForce;
//        Debug.Log("proj hf " + projectile.hitForce);
//        Debug.Log("ass hf " + hitForce);
//        projectile.ResetPos();
//        projectile.rb.AddForce(Direction * speed, ForceMode.Impulse);
//    }

//  Debug.Log(pool.projectileQueue.Count);



// projectile.rb.velocity = Direction * speed;
