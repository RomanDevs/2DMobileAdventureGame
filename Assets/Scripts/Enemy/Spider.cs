using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    void Start()
    {
        
    }

    protected override void Update()
    {
        
    }

    protected override void Attack()
    {
        base.Attack();
        Debug.Log("Spider Attack");
    }
}
