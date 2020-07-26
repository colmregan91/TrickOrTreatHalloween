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

    public void Throw(Vector3 dir, Vector3 ShotPos)
    {
        var projectile = EggProjectile.Get<EggProjectile>(ShotPos,Quaternion.identity);
        projectile.transform.SetParent(null);
        projectile.rb.useGravity = true;
        projectile.transform.LookAt(dir);

        Time.timeScale = 0;
        projectile.rb.velocity = new Vector3(0, 0, 3);
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
