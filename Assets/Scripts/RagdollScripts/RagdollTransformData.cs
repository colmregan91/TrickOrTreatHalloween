using System.Collections.Generic;
using UnityEngine;

public class RagdollTransformData
{
 //   public List<Transform> TargetRotations = new List<Transform>(); <<<<<<
    public static void copyTransformData(Transform sourceTransform, Transform destinationTransform/*, Vector3 vel*/)
    {
       
        if (sourceTransform.childCount != destinationTransform.childCount)
        {
            Debug.LogWarning("rdg and aj have different hierarchies!");
            return;
        }

        for (int i = 0; i < sourceTransform.childCount; i++)
        {
            var source = sourceTransform.GetChild(i);
            var dest = destinationTransform.GetChild(i);
            dest.position = source.position;
            dest.rotation = source.rotation;
            //    RagdollRB.velocity = vel;
            copyTransformData(source, dest);
        }
    }

    public static void SlerpTransforms(Transform sourceTransform, Transform destTransform, float percentageComplete)
    {
        {
            if (sourceTransform.childCount != destTransform.childCount)
            {
                Debug.Log(sourceTransform.childCount + "source"); Debug.Log(destTransform.childCount + "dest");
                Debug.LogWarning("player and Rotcopy have different hierarchies!");
                return;
            }
            for (int i = 0; i < sourceTransform.childCount; i++)
            {
                var source = sourceTransform.GetChild(i);
                var dest = destTransform.GetChild(i);

                if (source.name == "ItemHolder" && dest.name == "ItemHolder")
                {
                    continue;
                }

                if (source.name == "CATRigpelvis" && dest.name == "CATRigpelvis")
                {

                    source.position = Vector3.LerpUnclamped(source.position, dest.position, percentageComplete * 2);
                    //source.position = dest.position;
                }

                source.rotation = Quaternion.Slerp(source.rotation, dest.rotation, percentageComplete);

                SlerpTransforms(source, dest, percentageComplete);
            }
        }

      
    }
    //public static void GetStartRotationData(Transform sourceTransform, Quaternion destinationTransform/*, Vector3 vel*/)
    //{

    //    //if (sourceTransform.childCount != destinationTransform.tratchildCount)
    //    //{
    //    //    Debug.LogWarning("rdg and aj have different hierarchies!");
    //    //    return;
    //    //}

    //    for (int i = 0; i < sourceTransform.childCount; i++)
    //    {
    //        var source = sourceTransform.GetChild(i);
    //        //  var dest = destinationTransform.GetChild(i);
    //        //   dest.position = source.position;
    //        destinationTransform = source.rotation;
    //        //    RagdollRB.velocity = vel;
    //        GetStartRotationData(source, destinationTransform);
    //    }
    //}
}

