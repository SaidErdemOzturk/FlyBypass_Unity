using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BotController : RunnerBase
{
    private Transform lastPosition;
    public GameObject moveRoad;
    public GameObject MoveRoad 
    { 
        get 
        {
            return moveRoad; 
        } 
        set 
        { 
            moveRoad = value;
            MoveToRoad();
        } 
    }

    private void MoveToRoad()
    {
        transform.DODynamicLookAt(MoveRoad.transform.position, 1.5F);
    }
    void Update()
    {
        isClicked = true;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 5F, layerMask))
        {
            OnPlane();
        }
        else
        {
            OnAir();
        }
    }
    private void FixedUpdate()
    {
        PlayerMovement();
    }

    public override void PlayerMovement()
    {
        if(gameManager.GameState== GameState.Started)
        {
            PlayerForwardMovement();
            PlayerHorizontalMovement();
        }
    }
    private void PlayerHorizontalMovement()
    {
        MoveToRoad();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IFail>()?.Fail(Fail);
        other.GetComponent<IFlyCube>()?.GetCube(GetCube);
        other.GetComponent<IRoad>()?.MoveNextRoad(this);
    }

    private void PlayerForwardMovement()
    {
        rigidbody.velocity = transform.forward * playerSpeed + transform.up * onAir;
    }
}
