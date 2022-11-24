using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// �Q�[������UI�ɂ���X�N���v�g�B�e�L�X�g�̃C���X�^���X�K�v�B
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
        int minute = (int)_timer / 60;//��.time��60�Ŋ������l.
        int second = (int)_timer % 60;//�b.time��60�Ŋ������]��.
        _timeMinuteText.text = minute.ToString();
        _timeSecondText.text = second.ToString();
    }
    void WaveText()
    {
        _waveText.text = _count.ToString();
    }
}
