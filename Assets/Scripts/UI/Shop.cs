using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _shopPanel.SetActive(true);
            UIManager.Instance.OpenShop(other.GetComponent<Player>().GetDiamonds());
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _shopPanel.SetActive(false);
        }
    }
}
