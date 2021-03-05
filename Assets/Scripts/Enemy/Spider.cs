using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamagable
{
    [SerializeField] private GameObject _acidPrefab;
    private bool _readyToAttack = true;
    private WaitForSeconds _attackCDTime = new WaitForSeconds(2);
    public int Health { get; set; }
    protected override void Init()
    {
        idleAnimationName = "SpiderIdle";
        speed = 1;
        base.Init();
        Health = base.health;
    }

    protected override void Movement()
    {
        
    }

    public void Attack()
    {
        if (_readyToAttack)
        {
            Instantiate(_acidPrefab, transform.position, Quaternion.identity);
            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        _readyToAttack = false;
        yield return _attackCDTime;
        _readyToAttack = true;
        StopCoroutine(AttackCooldown());
    }

    public void Damage()
    {
        Debug.Log("Spider::Damage()");
        health--;
        if(health < 1)
        {
            anim.SetTrigger("Death");
            isDead = true;
            Destroy(GetComponent<BoxCollider2D>());
        }
    }
}
