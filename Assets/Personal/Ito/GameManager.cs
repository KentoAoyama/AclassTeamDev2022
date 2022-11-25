using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float WaveCenterCount = 0;
    public static float Timer = 0;
    public static float Score = 0;
    [SerializeField] PlayerController _player;
    [SerializeField] FadeSystem _sceneFade;
    private void Start()
    {
        _sceneFade.StartFadeIn();
        StartCoroutine(ScorePlus());
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
        WaveCenterCount++;
    }
    IEnumerator ScorePlus()
    {
        Score += WaveCenterCount;
        yield return new WaitForSeconds(1);
        StartCoroutine(ScorePlus());
    }
}
