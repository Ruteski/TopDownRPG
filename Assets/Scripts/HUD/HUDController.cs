using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Image _waterBar;
    [SerializeField] private Image _woodBar;
    [SerializeField] private Image _carrotBar;

    private Items _playerItems;

    private void Awake() {
        _playerItems = FindObjectOfType<Items>();
    }

    private void Start() {
        _waterBar.fillAmount = 0f;
        _woodBar.fillAmount = 0f;
        _carrotBar.fillAmount = 0f;
    }

    private void Update() {
        // TODO mudar essas 3 atrb para um metodo, que sera utilizado apenas quando ouver mudança nos valores
        _waterBar.fillAmount = _playerItems.TotalWater / _playerItems.WaterLimit1;
        _woodBar.fillAmount = _playerItems.TotalWood / _playerItems.WoodLimit;
        _carrotBar.fillAmount = _playerItems.TotalCarrots / _playerItems.CarrotsLimit;
    }
}
