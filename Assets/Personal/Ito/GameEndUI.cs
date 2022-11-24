using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ゲーム終わりのUIにつけるスクリプト。テキストのインスタンス必要。
/// </summary>
public class GameEndUI : MonoBehaviour
{
    float _timer = GameManager.Timer;
    float _count = GameManager._waveCenterCount;
    [SerializeField] Text _waveCountText;
    [SerializeField] Text _timeMinuteText;
    [SerializeField] Text _timeSecondText;
    [SerializeField] Text _scoreText;
    [SerializeField] Text _text;
    void Start()
    {
        Result();
        //TimeText();
        //WaveText();
        //ScoreText();
    }
    void Result()
    {
        int minute = (int)_timer / 60;//分.timeを60で割った値.
        int second = (int)_timer % 60;//秒.timeを60で割った余り.

        _text.text = $"{minute}分 {second}秒 × {_count}個 = {(_count * _timer)}";
    }
    //void TimeText()
    //{
    //    int minute = (int)_timer / 60;//分.timeを60で割った値.
    //    int second = (int)_timer % 60;//秒.timeを60で割った余り.
    //    _timeMinuteText.text = minute.ToString();
    //    _timeSecondText.text = second.ToString();

    //}
    //void WaveText()
    //{
    //    _waveCountText.text = _count.ToString();
    //}
    //void ScoreText()
    //{
    //    _scoreText.text = (_count * _timer).ToString();
    //}

}