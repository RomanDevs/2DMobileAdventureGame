using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    protected override void Init()
    {
        idleAnimationName = "SkeletonIdle";
        speed = 0.5f;
        base.Init();
    }
}
