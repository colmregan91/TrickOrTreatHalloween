using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggPRacticeDelete : MonoBehaviour
{
    public Transform[] dots;
    private Vector3 ballPos;
    private float z1, y1;
    public float shotMultiplier;

    public float dotSeparation = 1f;
    public float dotShift = 0f;						//How far the first dot is from the "ball"
    public Transform holder;
    public bool poweringX;
    public float chargeSpeed;
    private float vertRotationX;
    private float VertRotationY;
    public float YAimSmoother;

    public Vector3 ShotForce;
    public Rigidbody thrownEgg;
    public float divider;
    public Vector3 offsetPos;
    public void SetTrajectoryRender(Item value)
    {
        holder.gameObject.SetActive(value.ObjectType is EggObject);
    }
    void Start()
    {

        transform.root.GetComponent<playerEventHandler>().HandleItemChange += SetTrajectoryRender;
        ballPos = transform.position;

    }

    Vector3 ThrowStartPos()
    {
        return dots[0].position;
    }

    void CalculateEggArc()
    {
        // RaycastHit hit;

        for (int k = 0; k < dots.Length; k++)
        {
            //Each point of the trajectory will be given its position
            z1 = ballPos.z + ShotForce.z * Time.fixedDeltaTime * (dotSeparation * k + dotShift);    //X position for each point is found
            y1 = ballPos.y + ShotForce.y * Time.fixedDeltaTime * (dotSeparation * k + dotShift) - (-Physics2D.gravity.y / 2f * Time.fixedDeltaTime * Time.fixedDeltaTime * (dotSeparation * k + dotShift) * (dotSeparation * k + dotShift));    //Y position for each point is found
            dots[k].transform.position = holder.transform.position + transform.TransformDirection(new Vector3(0, y1, z1));
            //  lr.SetPosition(k, dots[k].transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {

        //VertRotationY += InputValues.YRotation * InputValues.RotationSensitivity * Time.deltaTime;
        //VertRotationY = Mathf.Clamp(VertRotationY, -50, 50);
        //weaponControl.ShotForce = new Vector3(0, weaponControl.egg_Y_ShootingPower, weaponControl.egg_X_ShootingPower);
       
        CalculateEggArc();

        ShotForce = new Vector3(0, -FindObjectOfType<camManager>().CamCont._tiltY / 2, 10);

        Vector3 rot = new Vector3(FindObjectOfType<camManager>().CamCont._tiltY, FindObjectOfType<camManager>().CamCont._tiltX, 0);

        transform.rotation = Quaternion.Euler(rot);
        //weaponControl.egg_Y_ShootingPower = Mathf.Lerp(weaponControl.egg_Y_ShootingPower, VertRotationY, Time.deltaTime * YAimSmoother);

        //  ControlTrajectory();

        //if (weaponControl.EggThrowCharging)
        //{
        //    weaponControl.eggCharge += Time.deltaTime * chargeSpeed;
        //    weaponControl.egg_X_ShootingPower = weaponControl.eggCharge;

        //}

        //weaponControl.eggCharge = Mathf.Clamp(weaponControl.eggCharge, weaponControl.EggCharge_MinClamp, weaponControl.EggCharge_MaxClamp);

    }

    public Vector3 GetThrowDir()
    {
        Vector3 Dir = new Vector3(0, ShotForce.y * shotMultiplier, ShotForce.z * shotMultiplier);
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
