using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : NPC
{
    [SerializeField] private CanvasGroup healthGroup;

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
}
