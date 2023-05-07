using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCubeController : MonoBehaviour,IFlyCube
{
    public void GetCube(Action<FlyCubeController> action)
    {
        action?.Invoke(this);
    }

    public void OnAir(Action action)
    {
        action?.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
