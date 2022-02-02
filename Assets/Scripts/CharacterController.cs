using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float speed;
    protected Vector2 direction;
    

    protected virtual void Start()
     {
         animator = GetComponent<Animator>();
     }

    protected virtual void Update()
    {
        move();
    }

    private void move()
    {
        transform.Translate( direction * speed * Time.deltaTime);
        if (direction.x != 0 || direction.y != 0)
        {
            animate(direction);
        }
        else
        {
            animator.SetLayerWeight(1,0);
        }
    }

    public void animate(Vector2 direction)
    {
        animator.SetLayerWeight(1,1);
       
        animator.SetFloat("horizontal", direction.x);
        animator.SetFloat("vertical", direction.y);
       
    }
}
