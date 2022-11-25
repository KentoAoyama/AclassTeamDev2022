using UnityEngine;

public class WaveGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("ゲームマネージャー")]
    private GameManager _gameManager;
    [SerializeField, Tooltip("プレイヤーのオブジェクト")]
    private GameObject _player;
    [SerializeField, Tooltip("生成するウェーブ")]
    private GameObject _waveCenter;
    [SerializeField, Tooltip("ウェーブを生成する範囲A")]
    private Transform _muzzleA;
    [SerializeField, Tooltip("ウェーブを生成する範囲B")]
    private Transform _muzzleB;
    [SerializeField, Tooltip("ランダム生成の条件")]
    private int _randomNum;
    [SerializeField, Tooltip("ジャンプの回数に応じた生成の条件")]
    private int _jampNum;

    private PlayerController _playerController;
    private bool _isRandomPos = false;
    private bool _isPlayerTransformPos = false;
    private void Start()
    {
        _playerController = _player.GetComponent<PlayerController>();
    }
    private void Update()
    {
        if (_playerController.JumpCount < 0)
        {
            RandomPos();
            PlayerTransformPos();
        }
    }
    /// <summary>
    /// ランダムな位置にウェーブセンターを生成する
    /// </summary>
    private void RandomPos()
    {
        if (_playerController.JumpCount % _randomNum == 0 && !_isRandomPos)
        {
            float x = Random.Range(_muzzleA.position.x, _muzzleB.position.x);
            float y = Random.Range(_muzzleA.position.y, _muzzleB.position.y);
            Instantiate(_waveCenter, new Vector2(x, y), _waveCenter.transform.rotation);
            _gameManager.WaveCenterCountPlus();
            _isRandomPos = true;
        }
        else if (_playerController.JumpCount % _randomNum != 0)
        {
            _isRandomPos = false;
        }
    }
    /// <summary>
    /// プレイヤーの位置にウェーブセンターを生成する
    /// </summary>
    private void PlayerTransformPos()
    {
        if (_playerController.JumpCount % _jampNum == 0 && !_isPlayerTransformPos)
        {
            Instantiate(_waveCenter, _player.transform.position, _waveCenter.transform.rotation);
            _gameManager.WaveCenterCountPlus();
            _isPlayerTransformPos = true;
        }
        else if (_playerController.JumpCount % _jampNum != 0)
        {
            _isPlayerTransformPos = false;
        }
    }
}
