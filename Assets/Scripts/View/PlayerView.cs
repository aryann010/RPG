using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
public class PlayerView : MonoBehaviour
{
    [SerializeField]
    protected Transform hitBox;
    [SerializeField] private GameObject[] spellPrefabs;
    [SerializeField] private statsView mana;
    // [SerializeField] private statsController playerHeath;
    [SerializeField] private Transform[] exitPoints;
    protected bool isElxirPicked = false;
    private Rigidbody2D rgb; public int Weapon = 0;
    [SerializeField] public statsView stats;
    private Transform currentTarget;
    public Transform target { get; set; }
    public bool isFireAttack = false, isIceAttack = false, isSwordAttack = false;
    protected Coroutine fireAttackRoutine, swordAttackRoutine, iceAttackRoutine;
    [SerializeField] private DialogueTrigger dialougetrigger; public Vector2 direction;
    [SerializeField] private SightBlock[] blocks;
    public Animator animator;
    public PlayerService playerService { get; set; }

 
    public int exitIndex = 2;
    public bool isMoving
    {
        get { return direction.x != 0 || direction.y != 0; }
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "elxir")
        {
            Debug.Log("picked");
            isElxirPicked = true;
            dialougetrigger.getStatus(true);


        }
    }
    public void SightBlock()
    {
        foreach (SightBlock b in blocks)
        {
            b.deactivate();

        }
        blocks[exitIndex].activate();
    }
    void Start()
    {
        stats.Initialize(100, 100);
        rgb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
      
        playerService.getInput();
        playerService.handleLayers();

    }

 

    private IEnumerator FireAttack()
    {
        currentTarget = target;
        isFireAttack = true;
        animator.SetBool("attack", isFireAttack);
        yield return new WaitForSeconds(2);
        if (currentTarget != null && inLineOfSight())
        {
            SpellView spell = Instantiate(spellPrefabs[0], exitPoints[exitIndex].position, quaternion.identity).GetComponent<SpellView>();
            spell.Initialize(currentTarget, 50);

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
            SpellView spell = Instantiate(spellPrefabs[1], exitPoints[exitIndex].position, quaternion.identity).GetComponent<SpellView>();
            spell.Initialize(currentTarget, 50);
        }

        animator.SetBool("attackFurther", isIceAttack);
        yield return new WaitForSeconds(1);
        stopIceAttack();


    }

    private IEnumerator SwordAttack()
    {

        isSwordAttack = true;
        animator.SetBool("attack", isSwordAttack);
        yield return new WaitForSeconds(1);
        //takeDamage(44);
        stopSwordAttack();
    }

    public void swordAttack()
    {
        SightBlock();
        if (Weapon == 1)
        {

            if (target != null && !isSwordAttack && !isMoving && inLineOfSight())
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

            if (target != null && !isIceAttack && !isMoving && inLineOfSight())
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


            if (target != null && !isFireAttack && !isMoving && inLineOfSight())
            {

                fireAttackRoutine = StartCoroutine(FireAttack());
            }
        }

    }

    private bool inLineOfSight()
    {
        if (target != null)
        {
            Vector2 targetDirection = target.transform.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDirection, Vector2.Distance(transform.position, target.transform.position), 256);
            if (hit.collider == null)
            {
                return true;
            }
        }

        return false;
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
            StopCoroutine(swordAttackRoutine);
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
