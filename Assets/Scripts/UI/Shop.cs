using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    private Player _player;
    private int _playerGems;
    private int _currentItem;
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
                _currentItem = 0;
                _itemCost = 200;
                break;
            case 1:
                UIManager.Instance.ShopSelection(-90);
                _currentItem = 1;
                _itemCost = 400;
                break;
            case 2:
                UIManager.Instance.ShopSelection(-180);
                _currentItem = 2;
                _itemCost = 100;
                break;
        }
    }

    public void BuyItem()
    {
        if(_playerGems >= _itemCost)
        {
            switch(_currentItem)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    GameManager.Instance._hasKey = true;
                    break;
            }
            _player.AddDiamonds(-_itemCost);
            _playerGems = _player.GetDiamonds();
            UIManager.Instance.OpenShop(_playerGems);
            _shopPanel.SetActive(false);
        }
        else
        {
            Debug.Log("You don't have enough gems");
            _shopPanel.SetActive(false);
        }
    }
}
