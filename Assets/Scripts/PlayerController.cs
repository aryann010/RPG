using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : CharacterController
{
   [SerializeField] private GameObject[] spellPrefabs;
    [SerializeField] private statsController health,mana;
    [SerializeField] private Transform[] exitPoints;
    private int exitIndex=2;
    
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
            exitIndex = 0;
            direction = Vector2.up;
        }

        if (Input.GetKey(KeyCode.A))
        {
            exitIndex = 3;
            direction=Vector2.left;
        }

        if (Input.GetKey(KeyCode.S))
        {
            exitIndex = 2;
            direction=Vector2.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            exitIndex = 1;
            direction=Vector2.right;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Weapon == 1)
            {
                if (!isThunderCast && !isMoving)
                {
                    attackRoutine = StartCoroutine(ThunderAttack());
                }
            }
        }
    }


    private IEnumerator ThunderAttack()
    {
        isThunderCast = true;
            animator.SetBool("attack", isThunderCast);
            yield return new WaitForSeconds(5);
            caseThunderSpell();
            animator.SetBool("attackFurther", isThunderCast);
            yield return new WaitForSeconds(1);
            stopAttack();
        

    }

    public void caseThunderSpell()
    {
        Instantiate(spellPrefabs[0],exitPoints[exitIndex].position, quaternion.identity); 
    }
 
}
