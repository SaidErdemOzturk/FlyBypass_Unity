using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailController : MonoBehaviour,IFail
{
    public void Fail(Action action)
    {
        action?.Invoke();
    }
}
