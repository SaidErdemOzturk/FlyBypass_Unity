using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackController : MonoBehaviour
{


    private float onAirDistanceCubeX;
    private float onAirDistanceCubeY;
    private float distanceCube;

    private GameObject stackObject;
    private GameObject leftStack;
    private GameObject rightStack;
    private GameObject tempObject;


    private StackManager stackManager;
    private RunnerBase playerController;

    private Vector3 tempScale;

    void Start()
    {
        stackManager = StackManager.GetInstance();
        onAirDistanceCubeX = stackManager.GetDistanceX();
        onAirDistanceCubeY = stackManager.GetDistanceY();
        distanceCube = stackManager.GetDistanceCube();
        stackObject = stackManager.GetPrefab();
        playerController = transform.parent.GetComponent<RunnerBase>();
        leftStack = transform.Find("LeftStack").transform.gameObject;
        rightStack = transform.Find("RightStack").transform.gameObject;
    }

    public void AddCube()
    {
        for (int i = 0; i < 3; i++)
        {
            tempObject = Instantiate(stackObject);
            tempObject.transform.SetParent(leftStack.transform);
            tempObject.transform.localPosition = new Vector3(0, 0, -leftStack.transform.childCount * distanceCube);
            tempObject.transform.localEulerAngles = Vector3.zero;

            tempObject = Instantiate(stackObject);
            tempObject.transform.SetParent(rightStack.transform);
            tempObject.transform.localPosition = new Vector3(0, 0, -rightStack.transform.childCount * distanceCube);
            tempObject.transform.localEulerAngles = Vector3.zero;
        }
        /*

        tempLeftObject = Instantiate(stackPrefab);
        tempLeftObject.transform.localScale = new Vector3(0.25F,0.25F,0.25F);
        tempLeftObject.transform.SetParent(leftStack.transform);
        tempLeftObject.transform.localPosition = new Vector3(0, 0,-leftStack.transform.childCount*distanceCube);
        tempLeftObject.transform.localEulerAngles = new Vector3(0, 0, 90);


        tempRightObject = Instantiate(stackPrefab);
        tempRightObject.transform.localScale = new Vector3(0.25F, 0.25F, 0.25F);
        tempRightObject.transform.SetParent(rightStack.transform);
        tempRightObject.transform.localPosition = new Vector3(0, 0, -rightStack.transform.childCount*distanceCube);
        tempRightObject.transform.localEulerAngles = new Vector3(0, 0, 90);*/
    }

    public void OnAir()
    {
        if (playerController.PlayerState != PlayerState.OnAir)
        {
            for (int i = 0; i < leftStack.transform.childCount; i++)
            {
                tempObject = leftStack.transform.GetChild(i).gameObject;
                tempScale = tempObject.transform.localScale;
                tempObject.transform.DOLocalMove(new Vector3(-i * onAirDistanceCubeX, i * onAirDistanceCubeY, 0), 0.01F * i);
                // tempOnAirObject.transform.localPosition = new Vector3(-i* onAirDistanceCubeX, i*onAirDistanceCubeY,0);
                tempObject.transform.localScale = new Vector3(tempScale.x, tempScale.y, tempScale.z + i * 0.1F);
                tempObject.transform.localEulerAngles = new Vector3(0, 0, 0);


                tempObject = rightStack.transform.GetChild(i).gameObject;
                tempObject.transform.DOLocalMove(new Vector3(i * onAirDistanceCubeX, i * onAirDistanceCubeY, 0), 0.01F * i);
                //tempOnAirObject.transform.localPosition = new Vector3(i*onAirDistanceCubeX,i*onAirDistanceCubeY,0);
                tempObject.transform.localScale = new Vector3(tempScale.x, tempScale.y, tempScale.z + i * 0.1F);
                tempObject.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            playerController.PlayerState = PlayerState.OnAir;
        }
    }

    public void RemoveCube()
    {
        tempObject = leftStack.transform.GetChild(leftStack.transform.childCount - 1).gameObject;
        tempObject.transform.SetParent(null);
        tempObject.AddComponent<Rigidbody>();
        tempObject.GetComponent<BoxCollider>().isTrigger = false;
        Destroy(tempObject, 2);

        tempObject = rightStack.transform.GetChild(rightStack.transform.childCount - 1).gameObject;
        tempObject.transform.SetParent(null);
        tempObject.AddComponent<Rigidbody>();
        tempObject.GetComponent<BoxCollider>().isTrigger = false;
        Destroy(tempObject, 2);
    }

    public int StackLength()
    {
        return leftStack.transform.childCount;
    }


}
