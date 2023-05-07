using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackManager : BaseSingleton<StackManager>
{

    [SerializeField] private float onAirDistanceCubeX;
    [SerializeField] private float onAirDistanceCubeY;
    [SerializeField] private float distanceCube;
    [SerializeField] private GameObject stackObject;

    public float GetDistanceX()
    {
        return onAirDistanceCubeX;
    }
    public float GetDistanceY()
    {
        return onAirDistanceCubeY;
    }
    public float GetDistanceCube()
    {
        return distanceCube;
    }

    public GameObject GetPrefab()
    {
        return stackObject;
    }
}
