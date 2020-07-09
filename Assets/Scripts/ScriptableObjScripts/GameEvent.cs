using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameEvent<T> : ScriptableObject
{
    public event Action<T> _Response;
    public event Action<T> _ResponseP2;

    public void RaiseGenericEventP1(T param)
    {

        _Response?.Invoke(param);
    }

    public void RaiseGenericEventP2(T param)
    {

        _ResponseP2?.Invoke(param);
    }
}

