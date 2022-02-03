using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    protected Animator animator;
    protected bool isThunderCast = false;
    private Rigidbody2D rgb;
    protected Coroutine attackRoutine;
    protected int Weapon = 0;
    public bool isMoving
    {
        get { return direction.x != 0 || direction.y != 0; }
    }
    [SerializeField] private float speed;
    protected Vector2 direction;
    
    protected virtual void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
         animator = GetComponent<Animator>();
     }

    protected virtual void Update()
    {
        handleLayers();
    }

    private void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        rgb.velocity = direction * speed;
    }

    public void handleLayers()
    {
        if (Weapon==1 && isMoving )
        {
            activateLayer("WalkWeapon");
            animator.SetFloat("horizontal", direction.x);
            animator.SetFloat("vertical", direction.y);
            stopAttack();
        }
        else if (Weapon==1&&isThunderCast)
        {
            
            activateLayer("ThunderCast");
            
        }
       else if (isMoving)
        {
           
            activateLayer("Walk");
            animator.SetFloat("horizontal", direction.x);
            animator.SetFloat("vertical", direction.y);
            stopAttack();
        }

        else if (Weapon==1)
        {
            activateLayer("IdleWeapon");
       }
        else if(Weapon==0)
        {
            activateLayer("Idle");
        }
        
        
        }

    public void activateLayer(string layername)
    {
        for (int i = 0; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i,0);
        }
        animator.SetLayerWeight(animator.GetLayerIndex(layername),1);
    }

    public void stopAttack()
    {
        if (attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
            isThunderCast = false;
            animator.SetBool("attack", isThunderCast);
            animator.SetBool("attackFurther", isThunderCast);
        }
    }
}
