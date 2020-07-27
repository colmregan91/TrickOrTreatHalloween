//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class IKcontrol : MonoBehaviour
//{
//    private Animator anim;
//    [SerializeField] private Transform aimTarget;
//    private Transform shoulder;
//    private Transform head;
//    private Transform chest;
//    private Transform Lowchest;
//    private Vector3 offset;
//    inventory inventory;
//    PlayerStateMachine stateMachine;
//    public bool hasControl;
//    public Vector3 posoffset;
//    // Start is called before the first frame update
//    void Start()
//    {
//        anim = GetComponentInChildren<Animator>();
//        shoulder = anim.GetBoneTransform(HumanBodyBones.RightShoulder);
//        chest = anim.GetBoneTransform(HumanBodyBones.UpperChest);
//        Lowchest = anim.GetBoneTransform(HumanBodyBones.Chest);
//        Debug.Log(shoulder);
//        head = anim.GetBoneTransform(HumanBodyBones.Head);
//        inventory = GetComponent<inventory>();
//        Debug.Log(inventory);
//    }



//    public void GiveCOntrolToIK(bool value)
//    {
//        hasControl = value;
//    }

//    private void LateUpdate()
//    {

//        if (!hasControl) return;

//      //  head.LookAt(aimTarget.position);

//        if (inventory.ActiveItem == null) return;

//        if (inventory.ActiveItem.ObjectType is FireworkObject)
//        {
//            chest.LookAt(aimTarget.position);
//            Lowchest.LookAt(aimTarget.position);
//            shoulder.LookAt(aimTarget.position);
//        }

//    }

//    // Update is called once per frame
//    //private void OnAnimatorIK(int layerIndex)
//    //{
//    //    Debug.Log("f");

//    //    anim.SetLookAtWeight(1);
//    //    anim.SetLookAtPosition(aimTarget.position);

//    //    anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
//    //    //  anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
//    //    anim.SetIKPosition(AvatarIKGoal.RightHand, aimTarget.position);
//    //    //      anim.SetIKRotation(AvatarIKGoal.RightHand, aimTarget.rotation);
//    //}
//}
