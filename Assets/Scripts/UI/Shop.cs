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

    public void SelectedItem(int buttonID)
    {
        //ID: 0 = Flame Sword, 1 = Flight Boots, 2 = Castle Key
        // 30, -70, -180
        switch(buttonID)
        {
            case 0:
                UIManager.Instance.ShopSelection(30);
                break;
            case 1:
                UIManager.Instance.ShopSelection(-90);
                break;
            case 2:
                UIManager.Instance.ShopSelection(-180);
                break;
        }
    }
}
