using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EggObject : ScriptableObject, Ithrowable
{
    public projectile EggProjectile;
    internal float CoolDownTime;

    public void SetMyPool(Transform shootpos)
    {
    //    Pool.GetPool(EggProjectile, 12);


    }

    public void Throw(Vector3 dir)
    {
        Debug.Log("thrown");
    }
}

//public void Throw(Vector3 dir, Vector3 StartPos, Pool Whichpool)
//{
//    var projectile = EggProjectile.Get<projectile>("Egg", Whichpool);
//    //  projectile.transform.LookAt(projectile.transform.position + Direction);
//    projectile.transform.position = StartPos;
//    projectile.rb.AddForce(dir, ForceMode.VelocityChange);
//}
