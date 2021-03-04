using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected int health;
    protected int speed;
    protected int gems;
    [SerializeField] protected Transform PointA, PointB;
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected string idleAnimationName;
    protected bool onB;


    protected virtual void Start()
    {
        Init();
    }
    protected virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        if(anim == null)
        {
            Debug.LogError("Animator in Enemy is NULL");
        }
        sprite = GetComponentInChildren<SpriteRenderer>();
        if (sprite == null)
        {
            Debug.LogError("Sprite Renderer in Enemy is NULL");
        }
    }

    protected virtual void Update()
    {
        Movement();
    }

    protected virtual void Movement()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(idleAnimationName) == false)
        {
            if (onB == false)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                sprite.flipX = false;
                //transform.position = Vector2.MoveTowards(transform.position, PointB.position, speed * Time.deltaTime);
                if (transform.position.x >= PointB.position.x)
                {
                    onB = true;
                    anim.SetTrigger("Idle");
                }
            }
            else if (onB == true)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                sprite.flipX = true;
                //transform.position = Vector2.MoveTowards(transform.position, PointA.position, speed * Time.deltaTime);
                if (transform.position.x <= PointA.position.x)
                {
                    onB = false;
                    anim.SetTrigger("Idle");
                }
            }
        }
    }

}
