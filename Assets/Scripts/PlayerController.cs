using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : CharactersController
{
   
   [SerializeField] private GameObject[] spellPrefabs;
    [SerializeField] private statsController health,mana;
    [SerializeField] private Transform[] exitPoints;
    [SerializeField] private SightBlock[] blocks;
    private Transform currentTarget;


    
    public Transform target { get; set; }
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
            swordAttack();
        }
        }
    private IEnumerator FireAttack()
    {
        currentTarget = target;
        isFireAttack = true;
            animator.SetBool("attack", isFireAttack);
            yield return new WaitForSeconds(2);
            if (currentTarget != null && inLineOfSight())
            {
                SpellController spell=   Instantiate(spellPrefabs[0],exitPoints[exitIndex].position, quaternion.identity).GetComponent<SpellController>();
                spell.target = currentTarget;  

            }
         animator.SetBool("attackFurther", isFireAttack);
            yield return new WaitForSeconds(1);
            stopAttack();
    }

    private IEnumerator IceAttack()
    {
        currentTarget = target;
        isIceAttack = true;
        animator.SetBool("attack", isIceAttack);
        yield return new WaitForSeconds(2);
        if (currentTarget != null && inLineOfSight())
        {
            SpellController spell=   Instantiate(spellPrefabs[1],exitPoints[exitIndex].position, quaternion.identity).GetComponent<SpellController>();
            spell.target = currentTarget;
        }
          
        animator.SetBool("attackFurther", isIceAttack);
        yield return new WaitForSeconds(1);
        stopIceAttack();
   

    }

    private IEnumerator SwordAttack(){
       
         isSwordAttack = true;
        animator.SetBool("attack",isSwordAttack);
        yield return new WaitForSeconds(1);
        stopSwordAttack();
    }

    public void swordAttack()
    {
        SightBlock();
        if (Weapon == 1)
        {
               
            if (target!=null && !isSwordAttack && !isMoving && inLineOfSight())
            {
               
                swordAttackRoutine = StartCoroutine(SwordAttack());
            }
        }
    }

    public void iceAttack()
    {
        SightBlock();
        if (Weapon == 1)
        {
               
            if (target!=null && !isIceAttack && !isMoving && inLineOfSight())
            {
               
                iceAttackRoutine = StartCoroutine(IceAttack());
            }
        }
    }
    public void fireAttack()
    {
        
        SightBlock();
        if (Weapon == 1)
        {

           
            if (target!=null && !isFireAttack && !isMoving && inLineOfSight())
            {
                
                fireAttackRoutine = StartCoroutine(FireAttack());
            }
        }
        
    }

    private bool inLineOfSight()
    {
        
        Vector2 targetDirection = target.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position,targetDirection,Vector2.Distance(transform.position,target.transform.position),256);
        if (hit.collider==null)
        {
            return true;
        }
        return false;
    }

    private void SightBlock()
    {
        foreach (SightBlock b in blocks)
        {
            b.deactivate();
            
        }
        blocks[exitIndex].activate();
    }
 
}
