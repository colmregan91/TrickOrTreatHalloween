using UnityEngine;

public class EggShooter : ITemShooter
{
    private EggAimer aimer;

    public EggObject CurrentlyEquippedEgg { get; private set; }

    private void Start()
    {
        aimer = GetComponent<EggAimer>();
    }
    public override void Use<t>(t CurrentHeldItem)
    {
        EggObject CurrentEgg = CurrentHeldItem as EggObject;
        CurrentlyEquippedEgg = CurrentEgg;
        shoot();
    }

    void shoot()
    {
        Vector3 dir =  aimer.GetThrowDir();
        Vector3 shotpos = aimer.GetStartofTrajectory();

        CurrentlyEquippedEgg.Throw(dir, shotpos);
    }
}




//int Hits = Physics.RaycastNonAlloc(ray, results, 100, lyrMsk, QueryTriggerInteraction.Collide);

//RaycastHit nearesthHit = new RaycastHit();
//double nearestDistance = double.MaxValue;

//for (int i = 0; i < Hits; i++)
//{
//    var dist = Vector3.Distance(transform.position, results[i].point);
//    if (dist < nearestDistance)
//    {
//        nearesthHit = results[i];
//        nearestDistance = dist;
//    }
//}

//if (nearesthHit.transform != null)
//{
//    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
//    cube.transform.position = nearesthHit.point;
//    cube.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
//}