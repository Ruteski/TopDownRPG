using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [Header("Amounts")]
    [SerializeField] private int _totalWood;
    [SerializeField] private float _currentWater;
    [SerializeField] private int _carrots;
    [SerializeField] private int _fishes;

    [Header("Limits")]
    private float _waterLimit = 50f;
    private float _carrotsLimit = 10;
    private float _woodLimit = 5;
    private float _fishesLimit = 3;

    public int TotalWood { get => _totalWood; set => _totalWood = value; }
    public float TotalWater { get => _currentWater; set => _currentWater = value; }
    public int TotalCarrots { get => _carrots; set => _carrots = value; }
    public int TotalFishes { get => _fishes; set => _fishes = value; }
    public float WaterLimit1 { get => _waterLimit; set => _waterLimit = value; }
    public float CarrotsLimit { get => _carrotsLimit; set => _carrotsLimit = value; }
    public float WoodLimit { get => _woodLimit; set => _woodLimit = value; }
    public float FishesLimit { get => _fishesLimit; set => _fishesLimit = value; }

    public void WaterLimit(float water) { 
        if (_currentWater < _waterLimit) {
            _currentWater += water;
        }
    }
}
