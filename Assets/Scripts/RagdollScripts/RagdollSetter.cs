using System;
using UnityEngine;

public class RagdollSetter
{
    public static void PrepRagdoll(Transform _AJTransform, Transform _RGDTransform)
    {

        RagdollTransformData.copyTransformData(_AJTransform, _RGDTransform);

        _AJTransform.gameObject.SetActive(false);
        _RGDTransform.gameObject.SetActive(true);
        _RGDTransform.SetParent(null);

    }

    public static void PrepPlayer(Transform _AJTransform, Transform _RGDTransform)
    {
        _RGDTransform.SetParent( _AJTransform.parent);
        _AJTransform.gameObject.SetActive(true);
        RagdollTransformData.copyTransformData(_RGDTransform, _AJTransform);
      
        _RGDTransform.gameObject.SetActive(false);
    }
}

