using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected int health;
    protected int speed;
    protected int gems;
    [SerializeField] protected Transform PointA, PointB;

    protected virtual void Attack()
    {
        Debug.Log("My name is " + this.gameObject.name);
    }

    protected abstract void Update();
}
