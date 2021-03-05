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
            anim.SetTrigger("Death");
            isDead = true;
            Destroy(GetComponent<BoxCollider2D>());
            GameObject thisDiamond = Instantiate(diamond, transform.position, Quaternion.identity);
            thisDiamond.GetComponent<Diamonds>().SetDiamonds(gems);
        }
    }

}
