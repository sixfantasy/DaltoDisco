using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wilberforce;

public class Filters : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Colorblind _colorblind;
    [SerializeField] private float _secondsToWait;

    private int _currentFilter;

    void Start()
    {
        _currentFilter = 0;
        StartCoroutine(ChangeColorBlindFilter());
    }

    IEnumerator ChangeColorBlindFilter()
    {
        yield return new WaitForSeconds(_secondsToWait);
        _colorblind.Type = ++_currentFilter % 4;
        /*if (_player != null)*/ StartCoroutine(ChangeColorBlindFilter());
    }
}
