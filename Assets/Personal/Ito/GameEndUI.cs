using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ゲーム終わりのUIにつけるスクリプト。テキストのインスタンス必要。
/// </summary>
public class GameEndUI : MonoBehaviour
{
    float _timer = GameManager.Timer;
    float _count = GameManager.WaveCenterCount;
    float _score = GameManager.Score;
    [SerializeField] Text _waveCountText;
    [SerializeField] Text _timeText;
    [SerializeField] Text _scoreText;
    void Start()
    {
        TimeText();
        WaveText();
        ScoreText();
    }
    void TimeText()
    {
        int minute = (int)_timer / 60;//分.timeを60で割った値.
        int second = (int)_timer % 60;//秒.timeを60で割った余り.
        _timeText.text = $"{minute} m {second} s";
    }
    void WaveText()
    {
        _waveCountText.text = _count.ToString();
    }
    void ScoreText()
    {
        _scoreText.text = _score.ToString();
    }

}