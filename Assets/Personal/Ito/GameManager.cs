using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float WaveCenterCount => _waveCenterCount;
    public static float _waveCenterCount;
    public static float Timer;
    [SerializeField] PlayerController _player;
    [SerializeField] FadeSystem _sceneFade;
    private void Start()
    {
        _sceneFade.StartFadeIn();
    }
    void Update()
    {
        TimerCount();
        if (_player.IsGameOver)
        {
            GameOver();
        }
    }
    void TimerCount()
    {
        Timer += Time.deltaTime;
    }
    void GameOver()
    {
        _sceneFade.StartFadeOut("GameEnd");
    }
    public void WaveCenterCountPlus()
    {
        _waveCenterCount++;
    }
}
