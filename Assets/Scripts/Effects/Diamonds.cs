using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
    [SerializeField] private int _diamondsToGive;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Player>().AddDiamonds(_diamondsToGive);
            Destroy(this.gameObject);
        }
    }
}
