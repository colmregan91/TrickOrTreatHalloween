using System;
using UnityEngine;


public class ITemShooter : ItemComponent
{

    private int lyrMsk;
    private Player player;
    private Camera _cam;

    // [SerializeField] private GameObject bullet;
    private FireworkObject CurrentlyEquippedFirework;
    public bool isShooting;
    public Transform ShootingPos;
    private crossHair Crosshair;
    private PlayerStateMachine playerStateMachine;

    public bool isRoundFinished { get { return CurrentlyEquippedFirework != null && CurrentlyEquippedFirework.RoundFinished; } }
    private void Awake()
    {
        lyrMsk = LayerMask.GetMask("Default");
    }

    private void OnDisable()
    {
        if (CurrentlyEquippedFirework != null)
        {
            CurrentlyEquippedFirework.RoundFinished = false; // what is this doing?
            CurrentlyEquippedFirework.ShotsFired = 0;
        }

        playerStateMachine.HandleStateChange -= HandleCanShootStateChange;
    }

    private void OnEnable()
    {
        player = transform.root.GetComponent<Player>();
        _cam = player._PlayerCamera;
        ShootingPos = transform.parent.parent.GetChild(2);
        Crosshair = _cam.transform.parent.GetComponentInChildren<crossHair>();
        playerStateMachine = player.playerstateMachine;
        playerStateMachine.HandleStateChange += HandleCanShootStateChange;
    }

    void HandleCanShootStateChange(Istate state)
    {
        if (state is DodgeFromIdleState || state is dodgeFromMoving)
        {
            if (isShooting)
                CancelShooting();
        }

    }
    public Vector3 GetDir()
    {
        Vector3 TargetPos = Crosshair.RandomPointTick();
        //  Vector3 poi = _cam.WorldToScreenPoint(TargetPos.normalized);
        Ray TargetPoint = _cam.ViewportPointToRay(Vector3.one / 2);
        return TargetPoint.direction.normalized;

    }


    void Shoot()
    {
        Vector3 dir = GetDir();
        Vector3 shotpos = ShootingPos.position;

        CurrentlyEquippedFirework.Shoot(dir, shotpos);

        if (CurrentlyEquippedFirework.RoundFinished)
        {
            CancelShooting();
        }
    }

    void CancelShooting()
    {
        isShooting = false;
        CancelInvoke("Shoot");
        _nextUseTime = Time.time + CurrentlyEquippedFirework.CoolDownTime;
    }

    public override void Use<t>(t CurrentHeldItem)
    {

        if (isShooting) return;



        FireworkObject CurrentFirework = CurrentHeldItem as FireworkObject;
        CurrentlyEquippedFirework = CurrentFirework;
        InvokeRepeating("Shoot", 0, CurrentlyEquippedFirework.FireRate);
        isShooting = true;



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