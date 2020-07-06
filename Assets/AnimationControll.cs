using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControll : MonoBehaviour
{
    private Animator animator;
    private float walkingSpeed;
    private Transform parent;

    void Start()
    {
        this.parent = transform.parent.parent;
        walkingSpeed = this.parent.GetComponent<MoveStraight>().getSpeed() / 10 + 1;
        animator = GetComponent<Animator>();
        animator.SetFloat("speed", walkingSpeed);
    }
 
    public void updateAnimationSpeed()
    {
        walkingSpeed = this.parent.GetComponent<MoveStraight>().getSpeed() / 10 + 1;
        animator.SetFloat("speed", walkingSpeed);
    }
}
