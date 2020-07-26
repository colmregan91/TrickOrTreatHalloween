using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKcontrol : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Transform aimTarget;
    private Transform shoulder;
    private Transform head;
    private Transform chest;
    private Vector3 offset;
    inventory inventory;
    PlayerStateMachine stateMachine;

    bool hasControl;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        shoulder = anim.GetBoneTransform(HumanBodyBones.RightShoulder);
        chest = anim.GetBoneTransform(HumanBodyBones.UpperChest);
        Debug.Log(shoulder);
        head = anim.GetBoneTransform(HumanBodyBones.Head);
        inventory = GetComponent<inventory>();
        GetComponent <PlayerStateMachine>().HandleStateChange += HandleStateChanged; // CANT USE IN SM AS NEEDS TO BE DONE IN LATEUPDATE , MOCK
        Debug.Log(inventory);
    }

    void HandleStateChanged(Istate state)
    {
        if (state is DodgeFromIdleState || state is dodgeFromMoving)
        {
            hasControl = false;
        }
        else
        {
            hasControl = true;
        }
    }
    private void LateUpdate()
    {
        head.LookAt(aimTarget.position);
     

        if (inventory.ActiveItem == null || !hasControl) return;

        if (inventory.ActiveItem.ObjectType is FireworkObject)
        {
            shoulder.LookAt(aimTarget.position);

        }

    }

    // Update is called once per frame
    //private void OnAnimatorIK(int layerIndex)
    //{
    //    Debug.Log("f");

    //    anim.SetLookAtWeight(1);
    //    anim.SetLookAtPosition(aimTarget.position);

    //    anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
    //    //  anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
    //    anim.SetIKPosition(AvatarIKGoal.RightHand, aimTarget.position);
    //    //      anim.SetIKRotation(AvatarIKGoal.RightHand, aimTarget.rotation);
    //}
}
