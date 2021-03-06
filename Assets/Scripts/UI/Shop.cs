using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    private Player _player;
    private int _playerGems;
    private int _itemCost;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _shopPanel.SetActive(true);
            _player = other.GetComponent<Player>();
            _playerGems = _player.GetDiamonds();
            UIManager.Instance.OpenShop(_playerGems);
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
                _itemCost = 200;
                break;
            case 1:
                UIManager.Instance.ShopSelection(-90);
                _itemCost = 400;
                break;
            case 2:
                UIManager.Instance.ShopSelection(-180);
                _itemCost = 100;
                break;
        }
    }

    public void BuyItem()
    {
        if(_playerGems >= _itemCost)
        {
            _player.AddDiamonds(-_itemCost);
            _playerGems = _player.GetDiamonds();
            UIManager.Instance.OpenShop(_playerGems);
        }
        else
        {
            _shopPanel.SetActive(false);
        }
    }
}
