using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canHurt = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
            Debug.Log("Hit: " + other.name.ToString());

        IDamagable hit = other.GetComponent<IDamagable>();

        if(hit != null)
        {
            if (_canHurt)
            {
                hit.Damage();
                StartCoroutine(AttackCooldown());
            }
        }
    }

    private IEnumerator AttackCooldown()
    {
        _canHurt = false;
        yield return new WaitForSeconds(0.5f);
        _canHurt = true;
    }
}
