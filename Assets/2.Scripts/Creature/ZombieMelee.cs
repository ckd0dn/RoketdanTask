using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMelee : Zombie
{
    protected override void OnDead()
    {
        base.OnDead();
        
        Managers.Object.Despawn(this);
    }
}
