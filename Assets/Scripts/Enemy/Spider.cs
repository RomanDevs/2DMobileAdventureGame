using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamagable
{
    //use for initialization
    public int Health { get; set; }
    protected override void Init()
    {
        idleAnimationName = "SpiderIdle";
        speed = 1;
        base.Init();
        Health = health;
    }

    public void Damage()
    {

    }
}
