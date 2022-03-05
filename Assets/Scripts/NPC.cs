using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : PlayerView
{
   

    public virtual void deSelect()
    {
        
    }

    public virtual Transform select()
    {
        return hitBox;
    }
}
