using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// �Q�[������UI�ɂ���X�N���v�g�B�e�L�X�g�̃C���X�^���X�K�v�B
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
        int minute = (int)_gameManager.Timer / 60;//��.time��60�Ŋ������l.
        int second = (int)_gameManager.Timer % 60;//�b.time��60�Ŋ������]��.
        _timeMinuteText.text = minute.ToString();
        _timeSecondText.text = second.ToString();
    }
    void ScoreText()
    {
        _scoreText.text = _gameManager.WaveCenterCount.ToString();
    }
}
