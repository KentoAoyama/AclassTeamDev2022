using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// �Q�[���I����UI�ɂ���X�N���v�g�B�e�L�X�g�̃C���X�^���X�K�v�B
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
        int minute = (int)_timer / 60;//��.time��60�Ŋ������l.
        int second = (int)_timer % 60;//�b.time��60�Ŋ������]��.

        _text.text = $"{minute}�� {second}�b �~ {_count}�� = {(_count * _timer)}";
    }
    //void TimeText()
    //{
    //    int minute = (int)_timer / 60;//��.time��60�Ŋ������l.
    //    int second = (int)_timer % 60;//�b.time��60�Ŋ������]��.
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