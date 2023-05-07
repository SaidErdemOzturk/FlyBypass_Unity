using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    OnPlane,
    OnAir,
    OnFinish,
}
public class PlayerController : RunnerBase
{
    public static PlayerController instance;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IFail>()?.Fail(Fail);
        other.GetComponent<IFlyCube>()?.GetCube(GetCube);
    }
    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            isClicked = true;
        }else if (Input.GetMouseButtonUp(0))
        {
            isClicked=false;
        }
        if (Physics.Raycast(transform.position, Vector3.down,out hit, 5F,layerMask))
        {
            OnPlane();
        }
        else
        {
            OnAir();
        }
    }

    public override void PlayerMovement()
    {
        if (gameManager.GameState == GameState.Started)
        {
            PlayerForwardMovement();
            PlayerHorizontalMovement();
        }

    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerForwardMovement()
    {
        rigidbody.velocity = transform.forward * playerSpeed + transform.up * onAir;
    }

    private void PlayerHorizontalMovement() 
    {
        if (isClicked)
        {
            if(Input.GetAxis("Mouse X") > 0)
            {
                if(horizontalInput<Input.GetAxis("Mouse X"))
                {
                    horizontalInput = Input.GetAxis("Mouse X");
                }
            }
            else if(Input.GetAxis("Mouse X")<0)
            {
                if(horizontalInput>Input.GetAxis("Mouse X"))
                {
                    horizontalInput = Input.GetAxis("Mouse X");
                }
            }
            horizontalInput = Mathf.Clamp(horizontalInput, -1, 1);
            transform.eulerAngles += new Vector3(0, horizontalInput * horizontalSpeed, 0);
        }
        else
        {
            horizontalInput = 0;
        }
    }
}