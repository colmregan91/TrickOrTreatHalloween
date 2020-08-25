
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggAimer : ItemAimer
{
    public Vector3 ShotForce;
    public Transform Trajectoryholder;
    public float shotMultiplier;
    IPlayer player;
    CamControl camControl;
    private eggTrajectoryControl trajectoryCont;

    public override void Start()
    {
        base.Start();
        
    }


    public Vector3 GetStartofTrajectory()
    {
        return Trajectoryholder.position;
    }
    public Quaternion GetStartofRotation()
    {
        return Trajectoryholder.rotation;
    }


    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        //VertRotationY += InputValues.YRotation * InputValues.RotationSensitivity * Time.deltaTime;
        //VertRotationY = Mathf.Clamp(VertRotationY, -50, 50);
        //weaponControl.ShotForce = new Vector3(0, weaponControl.egg_Y_ShootingPower, weaponControl.egg_X_ShootingPower);
        //weaponControl.egg_Y_ShootingPower = Mathf.Lerp(weaponControl.egg_Y_ShootingPower, VertRotationY, Time.deltaTime * YAimSmoother);

        //  ControlTrajectory();

        //if (weaponControl.EggThrowCharging)
        //{
        //    weaponControl.eggCharge += Time.deltaTime * chargeSpeed;
        //    weaponControl.egg_X_ShootingPower = weaponControl.eggCharge;

        //}

        //weaponControl.eggCharge = Mathf.Clamp(weaponControl.eggCharge, weaponControl.EggCharge_MinClamp, weaponControl.EggCharge_MaxClamp);

    }
    public override void OnDisable()
    {
        base.OnDisable();
    }

    public Vector3 GetThrowForce()
    {
        return Vector3.zero;
    }


}

