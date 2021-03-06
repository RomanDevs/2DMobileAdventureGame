using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance 
    {
        get 
        {
            if(_instance == null)
            {
                Debug.LogError("UI Manager is NULL");
            }
            return _instance;
        }
    }

    [SerializeField] private Text _gemCount;
    [SerializeField] private Image _selectionImg;
    [SerializeField] private Text _hUDGems;
    [SerializeField] private Image[] _healthUnits;

    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenShop(int gemCount)
    {
        _gemCount.text = gemCount.ToString() + "G";
    }

    public void ShopSelection(int yPos)
    {
        _selectionImg.rectTransform.anchoredPosition = new Vector2(_selectionImg.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateHUD(int gems)
    {
        _hUDGems.text = gems.ToString();
    }

    public void UpdateLives(int lives)
    {
        switch(lives)
        {
            case 0:
                _healthUnits[0].gameObject.SetActive(false);
                break;
            case 1:
                _healthUnits[1].gameObject.SetActive(false);
                break;
            case 2:
                _healthUnits[2].gameObject.SetActive(false);
                break;
            case 3:
                _healthUnits[3].gameObject.SetActive(false);
                break;
            case 4:
                foreach(Image unit in _healthUnits)
                {
                    unit.gameObject.SetActive(true);
                }
                break;
            default:
                break;
        }
    }
}
