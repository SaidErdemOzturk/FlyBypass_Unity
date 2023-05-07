using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFlyCube
{
    void GetCube(Action<FlyCubeController> action);

    void OnAir(Action action);
}
