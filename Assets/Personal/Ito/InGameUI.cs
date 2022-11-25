using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ゲーム中のUIにつけるスクリプト。テキストのインスタンス必要。
/// </summary>
public class InGameUI : MonoBehaviour
{
    float _timer = GameManager.Timer;
    float _count = GameManager.WaveCenterCount;
    float _score = GameManager.Score;
    [SerializeField] Text _waveText;
    [SerializeField] Text _timeMinuteText;
    [SerializeField] Text _timeSecondText;
    [SerializeField] Text _scoreText;
    void Update()
    {
        TimeText();
        WaveText();
        ScoreText();
    }
    void TimeText()
    {
        _timer = GameManager.Timer;
        int minute = (int)_timer / 60;//分.timeを60で割った値.
        int second = (int)_timer % 60;//秒.timeを60で割った余り.
        _timeMinuteText.text = $"{minute} m";
        _timeSecondText.text = $"{second} s";
    }
    void WaveText()
    {
        _count = GameManager.WaveCenterCount;
        _waveText.text = _count.ToString();
    }
    void ScoreText()
    {
        _score = GameManager.Score;
        _scoreText.text = _score.ToString();
    }
}
