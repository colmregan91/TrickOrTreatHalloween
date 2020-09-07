using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class EggObject : ScriptableObject
{
    public PooledMonoBehavior EggProjectile;
    public float shotMultiplier;

    public void Throw(Vector3 dir, Vector3 StartPos)
    {
        var projectile = EggProjectile.Get<EggProjectile>();
        //  projectile.transform.LookAt(projectile.transform.position + Direction);
        projectile.transform.position = StartPos;
        projectile.rb.useGravity = true;
        projectile.rb.AddForce(dir, ForceMode.VelocityChange);
    }

    public void SetMyPool()
    {
        Pool.GetPool(EggProjectile);
    }
}

//public void Throw(Vector3 dir, Vector3 StartPos, Pool Whichpool)
//{
//  
//    //  projectile.transform.LookAt(projectile.transform.position + Direction);
//    projectile.transform.position = StartPos;
//    projectile.rb.AddForce(dir, ForceMode.VelocityChange);
//}
