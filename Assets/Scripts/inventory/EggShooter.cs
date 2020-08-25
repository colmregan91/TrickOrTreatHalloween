using UnityEngine;

public class EggShooter : ITemShooter
{

    public EggObject CurrentlyEquippedEgg { get; private set; }
    private eggTrajectoryControl trajectory;
    public override void OnEnable()
    {   player = transform.root.GetComponent<Player>();
        playerStateMachine = player.playerstateMachine;
        playerStateMachine.HandleStateChange += HandleCanShootStateChange;

        trajectory = transform.root.GetComponentInChildren<eggTrajectoryControl>();
        trajectory.gameObject.SetActive(true);
        ShootingPos = trajectory.transform;
    }
    public override void OnDisable()
    {
        playerStateMachine.HandleStateChange -= HandleCanShootStateChange;
    }

    public override void Use<t>(t CurrentHeldItem)
    {
        EggObject CurrentEgg = CurrentHeldItem as EggObject;
        CurrentlyEquippedEgg = CurrentEgg;
        shoot();
    }

    void shoot()
    {

        CurrentlyEquippedEgg.Throw(trajectory.dots, ShootingPos.position, trajectory.ShotForce.magnitude);
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