using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private Animator _anim;
    private SpriteRenderer _mGSprite;
    private bool _onB;
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        if(_anim == null)
        {
            Debug.LogError("Moss Giant Animator is NULL");
        }
        _mGSprite = GetComponentInChildren<SpriteRenderer>();
        if(_mGSprite == null)
        {
            Debug.LogError("Moss Giant Sprite Renderer is NULL");
        }    
        speed = 2;
    }

    protected override void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("MossGiantIdle") == false)
        {
            if (_onB == false)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                _mGSprite.flipX = false;
                //transform.position = Vector2.MoveTowards(transform.position, PointB.position, speed * Time.deltaTime);
                if (transform.position.x >= PointB.position.x)
                {
                    _onB = true;
                    _anim.SetTrigger("Idle");
                }
            }
            else if (_onB == true)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                _mGSprite.flipX = true;
                //transform.position = Vector2.MoveTowards(transform.position, PointA.position, speed * Time.deltaTime);
                if (transform.position.x <= PointA.position.x)
                {
                    _onB = false;
                    _anim.SetTrigger("Idle");
                }
            }
        }
    }

}
