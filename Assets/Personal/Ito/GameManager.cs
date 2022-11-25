using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float WaveCenterCount = 0;
    public static float Timer = 0;
    public static float Score = 0;
    [SerializeField] PlayerController _player;
    [SerializeField] string _gameEndSceneName = "GameEnd";
    [SerializeField] FadeSystem _sceneFade;

    bool _isFinish = false;
    private void Start()
    {
        WaveCenterCount = 1;
        Timer = 0;
        Score = 0;
        _sceneFade.StartFadeIn();
        StartCoroutine(ScorePlus());
    }
    void Update()
    {
        TimerCount();
        if (_player.IsGameOver && !_isFinish)
        {
            _isFinish = true;
            GameOver();
        }
    }
    void TimerCount()
    {
        Timer += Time.deltaTime;
    }
    void GameOver()
    {
        _sceneFade.StartFadeOut(_gameEndSceneName);
    }
    public void WaveCenterCountPlus()
    {
        WaveCenterCount++;
    }
    IEnumerator ScorePlus()
    {
        Score += WaveCenterCount;
        yield return new WaitForSeconds(1);
        StartCoroutine(ScorePlus());
    }
}
