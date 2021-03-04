using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    //use for initialization
    protected override void Init()
    {
        idleAnimationName = "SpiderIdle";
        speed = 1;
        base.Init();
    }

}
