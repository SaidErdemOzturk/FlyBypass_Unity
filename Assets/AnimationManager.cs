using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : BaseSingleton<AnimationManager>
{

    public void StartGameAnim(Animator animator)
    {
        animator.SetBool("IsStarted", true);
    }

    public void OnPlaneAnim(Animator animator)
    {
        animator.SetBool("OnAir", false);
    }
    public void OnAirPlane(Animator animator)
    {
        animator.SetBool("OnAir",true);
    }

}
