﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    //use for initialization
        protected override void Init()
        {
            idleAnimationName = "MossGiantIdle";
            speed = 2;
            base.Init();
         }

}
