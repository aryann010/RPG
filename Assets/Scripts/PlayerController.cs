using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : CharacterController
{
 
    [SerializeField] private statsController health,mana;
    
    protected  override void Start()
    {
       
        base.Start();
       health.initialize1(100,100);
       mana.initialize1(100,100);
       
        
    }
    protected override void Update()
    {
        getInput();
        
        base.Update();
    }
    private void getInput()
    {
       
        if (Input.GetKey(KeyCode.I))
        {

            health.MyCurrentValue -= 10;
          mana.MyCurrentValue -= 10;


        }

        if (Input.GetKey(KeyCode.O))
        {
            
                health.MyCurrentValue += 10;
               mana.MyCurrentValue+= 10;

        }

        if (Input.GetKey(KeyCode.E))
        {
            Weapon = 1;
        }

        if (Input.GetKey(KeyCode.R))
        {
            Weapon = 0;
        }

        
        
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector2.up;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction=Vector2.left;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction=Vector2.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction=Vector2.right;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Weapon == 1)
            {
              attackRoutine= StartCoroutine(ThunderAttack());
            }
        }
    }


    private IEnumerator ThunderAttack()
    {
        if (!isThunderCast && !isMoving)
        {
            isThunderCast = true;
            animator.SetBool("attack", isThunderCast);
            yield return new WaitForSeconds(5);
            animator.SetBool("attackFurther", isThunderCast);
            yield return new WaitForSeconds(1);
            stopAttack();
        }

    }
 
}
