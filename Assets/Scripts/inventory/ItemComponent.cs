using System;
using UnityEngine;
//using UnityEngine.Experimental.Rendering.HDPipeline;

public abstract class ItemComponent : MonoBehaviour
{
    protected float _nextUseTime;
    

    public bool CanUse => Time.time >= _nextUseTime;

    public abstract void Use<t>(t CurrentHeldItem) where t : ScriptableObject;
}