using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    private Vector3 offset;
    private void Start()
    {
        offset = player.transform.position - transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position,player.transform.position-offset,0.5F);
    }


}
