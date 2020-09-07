using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggMan : MonoBehaviour
{
    public Transform[] dots;
    private Vector3 TrajStartPos;
    private float z1, y1;
    public float shotMultiplier;

    public float dotSeparation = 1f;
    private float dotShift = 4.39f;						//How far the first dot is from the "ball"
    public Transform holder;
    public bool poweringX;
    public float chargeSpeed;
    private float vertRotationX;
    private float VertRotationY;
    public float YAimSmoother;
    public Vector3 ShotForce;
    public float egg_X_ShootingPower;
    public float egg_Y_ShootingPower;
    private float eggCharge;
    private float EggCharge_MinClamp;
    private float EggCharge_MaxClamp;
    public void SetTrajectoryRender(bool value)
    {
        holder.gameObject.SetActive(value);
    }
    void Start()
    {
        egg_X_ShootingPower = 18f;
        egg_Y_ShootingPower = 12f;
        eggCharge = EggCharge_MinClamp;


    }


    public Vector3 ThrowStartPos()
    {
        return dots[0].position;
    }

    void CalculateEggArc()
    {
        // RaycastHit hit;

        for (int k = 0; k < dots.Length; k++)
        {
            //Each point of the trajectory will be given its position
            z1 = TrajStartPos.z + ShotForce.z * Time.fixedDeltaTime * (dotSeparation * k + dotShift);    //X position for each point is found
            y1 = TrajStartPos.y + ShotForce.y * Time.fixedDeltaTime * (dotSeparation * k + dotShift) - (-Physics2D.gravity.y / 2f * Time.fixedDeltaTime * Time.fixedDeltaTime * (dotSeparation * k + dotShift) * (dotSeparation * k + dotShift));    //Y position for each point is found
            dots[k].transform.position = holder.transform.position + transform.TransformDirection(new Vector3(0, y1, z1));
            //  lr.SetPosition(k, dots[k].transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        VertRotationY += Input.GetAxis("Vertical") * Time.deltaTime;
        VertRotationY = Mathf.Clamp(VertRotationY, -50, 50);

        ShotForce = new Vector3(0, egg_Y_ShootingPower, egg_X_ShootingPower);

        CalculateEggArc();

        egg_Y_ShootingPower = Mathf.Lerp(egg_Y_ShootingPower, VertRotationY, Time.deltaTime * YAimSmoother);

        //  ControlTrajectory();

        //if (weaponControl.EggThrowCharging)
        //{
        //    weaponControl.eggCharge += Time.deltaTime * chargeSpeed;
        //    weaponControl.egg_X_ShootingPower = weaponControl.eggCharge;

        //}
        if (holder.gameObject.activeSelf)
        {

            Vector3 rot = transform.root.GetComponent<Player>().CamManager.CamCont.GetCamOrientation();

            transform.rotation = Quaternion.Euler(rot);
        }


        eggCharge = Mathf.Clamp(eggCharge,EggCharge_MinClamp, EggCharge_MaxClamp);

    }

    public Vector3 GetThrowDir()
    {
        //      Vector3 Dir = new Vector3(0, ShotForce.y * shotMultiplier, ShotForce.z * shotMultiplier);
        Vector3 Dir = this.transform.forward * 10;
        return Dir;
    }

    //void ControlTrajectory()
    //{
    //    if (InputValues.isAiming && weaponControl.GetCurrentWeaponSlot() == 1 && InputValues.CanThrow)
    //    {
    //        SetTrajectoryRender(true);
    //    }
    //    else
    //    {
    //        SetTrajectoryRender(false);
    //    }
    //}

}
