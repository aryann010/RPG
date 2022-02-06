using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharactersController : MonoBehaviour
{
   
    
    protected Animator animator;
    protected bool isFireAttack = false,isIceAttack=false,isSwordAttack=false;
    private Rigidbody2D rgb;
    protected Coroutine fireAttackRoutine,swordAttackRoutine,iceAttackRoutine;
    protected int Weapon = 0;
    [SerializeField]
    protected Transform hitBox;
  
  
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
        else if (Weapon==1&&isFireAttack)
        {
            
            activateLayer("FireAttack");
            
            
        }
        else if(Weapon==1 && isIceAttack)
        {
            activateLayer("IceAttack");
           
        }
        else if (Weapon == 1 && isSwordAttack)
        {
            activateLayer("SwordAttack");
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
        if (fireAttackRoutine != null)
        {
            
            StopCoroutine(fireAttackRoutine);
            isFireAttack = false;
            animator.SetBool("attack", isFireAttack);
            animator.SetBool("attackFurther", isFireAttack);
        }
    }
    public void stopSwordAttack()
    {
        if (swordAttackRoutine != null)
        {
            StopCoroutine( swordAttackRoutine);
            isSwordAttack = false;
            animator.SetBool("attack", isSwordAttack);

        }
    }
    public void stopIceAttack()
    {
        if (iceAttackRoutine != null)
        {
            StopCoroutine(iceAttackRoutine);
            isIceAttack = false;
           animator.SetBool("attack", isIceAttack);
            
            animator.SetBool("attackFurther", isIceAttack);
        }
    }
}
