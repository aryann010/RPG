using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingletonGeneric<T> : MonoBehaviour where T: MonoSingletonGeneric<T>
{
    public static T instance { get; private set; }

    protected virtual void awake()
    {
        if (instance == null)
        {
            instance = (T)this;
        }
        else
        {
            Destroy(this);
        }
    }
    
}
