using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wepCont : MonoBehaviour
{
    public float egg_X_ShootingPower;
    public float eggCharge;
    public float EggCharge_MinClamp = -50;
    public float egg_Y_ShootingPower;
    public Vector3 ShotForce;
    public float EggCharge_MaxClamp = 50;
    public eggMan eggm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            //rb.useGravity = true;
            //rb.velocity = Vector3.zero;
            //rb.gameObject.transform.position = eggm.ThrowStartPos();
            //rb.AddForce(eggm.GetThrowDir(), ForceMode.VelocityChange);
        }
    }
}
