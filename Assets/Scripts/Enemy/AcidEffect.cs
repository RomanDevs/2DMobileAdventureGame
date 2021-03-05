using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    private float _speed = 3f;
    private float _fallingSpeed = 0.3f;
    private bool _canHurt = true;

    private void Start()
    {
        Destroy(this.gameObject, 5);
    }

    void Update()
    {
        transform.Translate(new Vector2(_speed, -_fallingSpeed) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IDamagable hit = other.GetComponent<IDamagable>();

            if(hit != null)
            {
                if(_canHurt)
                {
                    hit.Damage();
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
