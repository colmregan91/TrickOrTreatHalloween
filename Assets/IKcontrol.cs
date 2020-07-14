using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKcontrol : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Transform aimTarget;
    private Transform shoulder;
    private Transform head;
    private Vector3 offset;
    public Vector3 Posoffset;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponentInChildren<Animator>();
        shoulder = anim.GetBoneTransform(HumanBodyBones.RightShoulder);
        head = anim.GetBoneTransform(HumanBodyBones.Head);
    }

    private void LateUpdate()
    {
        head.LookAt(aimTarget.position);

        if (player.inventory.ActiveItem == null) return;

        if (player.inventory.ActiveItem.ObjectType is FireworkObject)
        {
            shoulder.LookAt(aimTarget.position + Posoffset);

            shoulder.rotation = shoulder.rotation * Quaternion.Euler(offset);
        }

    }

    // Update is called once per frame
    private void OnAnimatorIK(int layerIndex)
    {
        Debug.Log("f");

        anim.SetLookAtWeight(1);
        anim.SetLookAtPosition(aimTarget.position);

        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        //  anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
        anim.SetIKPosition(AvatarIKGoal.RightHand, aimTarget.position);
        //      anim.SetIKRotation(AvatarIKGoal.RightHand, aimTarget.rotation);
    }
}
