using UnityEngine;

public class EggShooter : ITemShooter
{

    public EggObject CurrentlyEquippedEgg { get; private set; }
    private eggTrajectoryControl trajectory;

    public float egg_X_ShootingPower;
    public float eggCharge;
    public float EggCharge_MinClamp = -50;
    public float egg_Y_ShootingPower;
    public Vector3 ShotForce;
    public float EggCharge_MaxClamp = 50;
    public eggMan eggManager;

    public override void OnEnable()
    {
       
     
        player = transform.root.GetComponent<Player>();
        playerStateMachine = player.playerstateMachine;
        playerStateMachine.HandleStateChange += HandleCanShootStateChange;

        eggManager = player.transform.Find("EggTrajectoryStart").GetComponent<eggMan>();
        eggManager.SetTrajectoryRender(true);
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

        CurrentlyEquippedEgg.Throw(eggManager.GetThrowDir(), eggManager.ThrowStartPos());
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