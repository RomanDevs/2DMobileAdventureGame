using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamagable
{
    public int Health { get; set; }
    protected override void Init()
    {
        idleAnimationName = "SkeletonIdle";
        speed = 0.5f;
        base.Init();
        Health = base.health;
    }
    public void Damage()
    {
        health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);
        if(health < 1)
        {
            Destroy(this.gameObject);
        }
    }

}
