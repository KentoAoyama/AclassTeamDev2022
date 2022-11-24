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
    float _count = GameManager._waveCenterCount;
    [SerializeField] Text _waveText;
    [SerializeField] Text _timeMinuteText;
    [SerializeField] Text _timeSecondText;
    void Update()
    {
        TimeText();
        WaveText();
    }
    void TimeText()
    {
        int minute = (int)_timer / 60;//分.timeを60で割った値.
        int second = (int)_timer % 60;//秒.timeを60で割った余り.
        _timeMinuteText.text = minute.ToString();
        _timeSecondText.text = second.ToString();
    }
    void WaveText()
    {
        _waveText.text = _count.ToString();
    }
}
