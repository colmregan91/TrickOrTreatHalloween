
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
        player = transform.root.GetComponent<IPlayer>();
        Trajectoryholder.SetParent(player.playerTransform);
        Trajectoryholder.localPosition = new Vector3(0.5f, Trajectoryholder.localPosition.y, Trajectoryholder.localPosition.z);
        camControl = player.CamManager.CamCont;
        trajectoryCont = Trajectoryholder.GetComponent<eggTrajectoryControl>();
    }

 
    public Vector3 GetStartofTrajectory()
    {
        return trajectoryCont.dots[0].position;
    }



    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        //VertRotationY += InputValues.YRotation * InputValues.RotationSensitivity * Time.deltaTime;
        //VertRotationY = Mathf.Clamp(VertRotationY, -50, 50);
        //weaponControl.ShotForce = new Vector3(0, weaponControl.egg_Y_ShootingPower, weaponControl.egg_X_ShootingPower);


        ShotForce = new Vector3(0, -camControl._tiltY / 2, 10);

        Vector3 rot = camControl.GetCamOrientation();

        Trajectoryholder.transform.rotation = Quaternion.Euler(rot);

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

    public Vector3 GetThrowDir()
    {
     
            return trajectoryCont.dots[1].localPosition;
        

   
    }


}

