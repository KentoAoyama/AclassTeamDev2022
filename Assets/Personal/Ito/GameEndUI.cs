using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// �Q�[���I����UI�ɂ���X�N���v�g�B�e�L�X�g�̃C���X�^���X�K�v�B
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
        int minute = (int)_timer / 60;//��.time��60�Ŋ������l.
        int second = (int)_timer % 60;//�b.time��60�Ŋ������]��.
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