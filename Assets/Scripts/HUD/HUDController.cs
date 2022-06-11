using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Image _waterBar;
    [SerializeField] private Image _woodBar;
    [SerializeField] private Image _carrotBar;
    [SerializeField] private Image _fishBar;

    [Header("Tools")]
    //[SerializeField] private Image _axeUI;
    //[SerializeField] private Image _shovelUI;
    //[SerializeField] private Image _bucketUI;

    public List<Image> toolsUI = new List<Image>();

    [SerializeField] private Color _selectColor;
    [SerializeField] private Color _alphaColor;

    private Items _playerItems;
    private PlayerController _playerController;

    private void Awake() {
        _playerItems = FindObjectOfType<Items>();
        //_playerController = FindObjectOfType<PlayerController>();
        _playerController = _playerItems.GetComponent<PlayerController>();
    }

    private void Start() {
        _waterBar.fillAmount = 0f;
        _woodBar.fillAmount = 0f;
        _carrotBar.fillAmount = 0f;
        _fishBar.fillAmount = 0f;
    }

    private void Update() {
        // TODO mudar essas 3 atrb para um metodo, que sera utilizado apenas quando ouver mudança nos valores
        _waterBar.fillAmount = _playerItems.TotalWater / _playerItems.WaterLimit1;
        _woodBar.fillAmount = _playerItems.TotalWood / _playerItems.WoodLimit;
        _carrotBar.fillAmount = _playerItems.TotalCarrots / _playerItems.CarrotsLimit;
        _fishBar.fillAmount = _playerItems.TotalFishes / _playerItems.FishesLimit;

        for (var i = 1; i <= toolsUI.Count; i++) {
            if (i == _playerController.HandlingObj) {
                toolsUI[i-1].color = _selectColor;
            } else {
                toolsUI[i-1].color = _alphaColor;
            }
            
        }
    }
}
