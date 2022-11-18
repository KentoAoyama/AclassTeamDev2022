using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ゲーム中のUIにつけるスクリプト。テキストのインスタンス必要。
/// </summary>
public class InGameUI : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] Text _scoreText;
    [SerializeField] Text _timeMinuteText;
    [SerializeField] Text _timeSecondText;
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        TimeText();
        ScoreText();
    }
    void TimeText()
    {
        int minute = (int)_gameManager.Timer / 60;//分.timeを60で割った値.
        int second = (int)_gameManager.Timer % 60;//秒.timeを60で割った余り.
        _timeMinuteText.text = minute.ToString();
        _timeSecondText.text = second.ToString();
    }
    void ScoreText()
    {
        _scoreText.text = _gameManager.WaveCenterCount.ToString();
    }
}
