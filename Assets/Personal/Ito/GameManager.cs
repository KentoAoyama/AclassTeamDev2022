using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float WaveCenterCount => _waveCenterCount;
    [SerializeField] private float _waveCenterCount;
    public float Timer => _timer;//get‚¾‚¯‚ç‚µ‚¢
    [SerializeField] private float _timer;
    [SerializeField] GameObject _player;

    private void Start()
    {
    
    }
    void Update()
    {
        TimerCount();
    }
    void TimerCount()
    {
        _timer += Time.deltaTime;
    }
    public void WaveCenterCountPlus()
    {
        _waveCenterCount++;
    }
}
