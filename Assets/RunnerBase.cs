using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RunnerBase : MonoBehaviour
{

    [SerializeField] protected float playerSpeed;
    [SerializeField] protected float horizontalSpeed;
    [SerializeField] protected LayerMask layerMask;
    [SerializeField] protected float distanceCube;

    protected AnimationManager animationManager;
    protected StackController stackController;
    protected GameManager gameManager;
    protected Rigidbody rigidbody;

    protected float horizontalInput;
    protected float onAir;

    protected bool isClicked;
    protected bool onPlane;
    protected bool destroyCoolDown;

    protected Vector3 tempGravity;

    protected GameObject leftStack;
    protected GameObject rightStack;

    protected Animator animator;

    protected RaycastHit hit;
    public PlayerState PlayerState { get; set; }

    void Awake()
    {
        gameManager = GameManager.GetInstance();
        animationManager = AnimationManager.GetInstance();
        animator = transform.GetComponentInChildren<Animator>();
        stackController = transform.Find("Stack").GetComponent<StackController>();
        rigidbody = GetComponent<Rigidbody>();
        tempGravity = Physics.gravity;
        destroyCoolDown = true;
        PlayerState = PlayerState.OnPlane;
        leftStack = stackController.transform.Find("LeftStack").gameObject;
        rightStack = stackController.transform.Find("RightStack").gameObject;
    }

    public abstract void PlayerMovement();


    protected void GetCube(FlyCubeController cube)
    {
        Destroy(cube.gameObject);
        stackController.AddCube();
    }

    protected void OnPlane()
    {
        onPlane = true;
        onAir = 0;

        animationManager.OnPlaneAnim(animator);
    }

    protected void OnAir()
    {
        animationManager.OnAirPlane(animator);
        if (onPlane)
        {
            onAir = 10;
        }
        if (isClicked)
        {
            if (stackController.StackLength() > 0)
            {
                if (destroyCoolDown)
                {
                    StartCoroutine(DestroyCube());
                }
                if (onAir < 0)
                {
                    onAir -= Time.deltaTime;
                }
                else
                {
                    onAir -= Time.deltaTime * 10;
                }
            }
            else
            {
                onAir -= Time.deltaTime * 5;
            }
        }
        else
        {
            onAir -= Time.deltaTime * 5;
        }

        onPlane = false;
    }

    IEnumerator DestroyCube()
    {
        stackController.OnAir();
        destroyCoolDown = false;
        yield return new WaitForSeconds(0.25F);
        stackController.RemoveCube();
        destroyCoolDown = true;
    }
    protected void Fail()
    {
        gameObject.SetActive(false);
    }
}
