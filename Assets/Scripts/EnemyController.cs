using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : NPC
{
    private Transform target;
    [SerializeField] private CanvasGroup healthGroup;
   // [SerializeField] private statsController enemyHealth;

    public override Transform select()
    {
        healthGroup.alpha = 1;
        return base.select();
    }

    public override void deSelect()
    {
        healthGroup.alpha = 0;
        base.deSelect();
    }
    public void takeDamage(float dmg)
    {

    }
}
