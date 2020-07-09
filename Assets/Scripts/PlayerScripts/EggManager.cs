//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class EggManager : MonoBehaviour
//{ 
//    public Transform[] dots;
//    private Vector3 ballPos;
//    private float z1, y1;
//    public float shotMultiplier;
    
//    public float dotSeparation = 1f;
//    private float dotShift = 4.39f;						//How far the first dot is from the "ball"
//    public Transform holder;
//    public bool poweringX;
//    public float chargeSpeed;
//    private SO_InputValues InputValues;
//    private SO_WeaponControl weaponControl;
//    private float vertRotationX;
//    private float VertRotationY;
//    public float YAimSmoother;
  

//    private void Awake()
//    {
//        InputManager input = transform.root.GetComponent<InputManager>();
       
//        InputValues = input.GetInputValues();
//        weaponControl = input.GetWeaponController();
//        //lr = holder.GetComponentInChildren<LineRenderer>();
//    }

//    public void SetTrajectoryRender(bool value)
//    {
//        holder.gameObject.SetActive(value);
//    }
//    void Start()
//    {
       
//        weaponControl.egg_X_ShootingPower = 18f;
//        weaponControl.egg_Y_ShootingPower = 12f;
//        weaponControl.eggCharge = weaponControl.EggCharge_MinClamp;
//        ballPos = transform.position;

//    }
//    private void OnEnable()
//    {
//        weaponControl.OnThrow += GetThrowDir;
//        weaponControl.OnStartThrow += ThrowStartPos;


//    }
//    private void OnDisable()
//    {
//        weaponControl.OnThrow -= GetThrowDir;
//        weaponControl.OnStartThrow += ThrowStartPos;

//    }

//    Vector3 ThrowStartPos()
//    {
//        return dots[0].position;
//    }

//    void CalculateEggArc(Vector3 ShotForce)
//    {
//       // RaycastHit hit;

//        for (int k = 0; k < dots.Length; k++)
//        {
//                    //Each point of the trajectory will be given its position
//            z1 = ballPos.z + weaponControl.ShotForce.z * Time.fixedDeltaTime * (dotSeparation * k + dotShift);    //X position for each point is found
//            y1 = ballPos.y + weaponControl.ShotForce.y * Time.fixedDeltaTime * (dotSeparation * k + dotShift) - (-Physics2D.gravity.y / 2f * Time.fixedDeltaTime * Time.fixedDeltaTime * (dotSeparation * k + dotShift) * (dotSeparation * k + dotShift));    //Y position for each point is found
//            dots[k].transform.position = holder.transform.position + transform.TransformDirection(new Vector3(0, y1, z1));
//          //  lr.SetPosition(k, dots[k].transform.position);
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        VertRotationY += InputValues.YRotation * InputValues.RotationSensitivity * Time.deltaTime;
//        VertRotationY = Mathf.Clamp(VertRotationY, -50, 50);
//        weaponControl.ShotForce = new Vector3(0, weaponControl.egg_Y_ShootingPower, weaponControl.egg_X_ShootingPower);

//        CalculateEggArc(weaponControl.ShotForce);

//        weaponControl.egg_Y_ShootingPower = Mathf.Lerp(weaponControl.egg_Y_ShootingPower, VertRotationY, Time.deltaTime * YAimSmoother);

//        //  ControlTrajectory();

//        if (weaponControl.EggThrowCharging)
//        {
//            weaponControl.eggCharge += Time.deltaTime * chargeSpeed;
//            weaponControl.egg_X_ShootingPower = weaponControl.eggCharge;

//        }

//        weaponControl.eggCharge = Mathf.Clamp(weaponControl.eggCharge, weaponControl.EggCharge_MinClamp, weaponControl.EggCharge_MaxClamp);
     
//    }
      
//    public Vector3 GetThrowDir()
//    {
//        Vector3 Dir = transform.TransformDirection(new Vector3(0, weaponControl.ShotForce.y * shotMultiplier, weaponControl.ShotForce.z * shotMultiplier));
//        return Dir;
//    }

//    void ControlTrajectory()
//    {
//        if (InputValues.isAiming && weaponControl.GetCurrentWeaponSlot() == 1 && InputValues.CanThrow)
//        {
//            SetTrajectoryRender(true);
//        }
//        else
//        {
//            SetTrajectoryRender(false);
//        }
//    }

//}

