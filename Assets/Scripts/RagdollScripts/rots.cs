using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rots : MonoBehaviour
{
    public Transform aj1;
    public Transform ajnorm;


    private void Update()
    {
        copyTransformData(ajnorm, aj1, Vector3.zero);
    }
    public void copyTransformData(Transform sourceTransform, Transform destinationTransform, Vector3 vel)
    {

        if (sourceTransform.childCount != destinationTransform.childCount)
        {
            Debug.LogWarning("rdg and aj have different hierarchies!");
            return;
        }
        Debug.Log(sourceTransform.childCount);
        for (int i = 0; i < sourceTransform.childCount; i++)
        {
            var source = sourceTransform.GetChild(i);
            var dest = destinationTransform.GetChild(i);

            dest.rotation = Quaternion.Slerp(dest.rotation, source.rotation, 0.01f);
            //    RagdollRB.velocity = vel;
            copyTransformData(source, dest, vel);
        }


    }
}
