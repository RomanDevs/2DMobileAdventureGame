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
            Health = health;
         }

    public void Damage()
    {

    }

}
