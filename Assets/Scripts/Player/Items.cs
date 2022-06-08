using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private int _totalWood;
    [SerializeField] private float _currentWater;
    [SerializeField] private int _carrots;

    private float _waterLimit = 50;

    public int TotalWood { get => _totalWood; set => _totalWood = value; }
    public float TotalWater { get => _currentWater; set => _currentWater = value; }
    public int Carrots { get => _carrots; set => _carrots = value; }

    public void WaterLimit(float water) { 
        if (_currentWater < _waterLimit) {
            _currentWater += water;
        }
    }
}
