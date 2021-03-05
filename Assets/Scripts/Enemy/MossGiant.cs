using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamagable
{
    //use for initialization
    public int Health { get; set; }
        protected override void Init()
        {
            idleAnimationName = "MossGiantIdle";
            speed = 2;
            base.Init();
            Health = base.health;
         }

    public void Damage()
    {
        Debug.Log("MossGiant::Damage()");
        health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);
        if (health < 1)
        {
            Destroy(this.gameObject);
        }
    }

}
