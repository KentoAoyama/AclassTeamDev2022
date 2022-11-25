using UnityEngine;

public class WaveGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("�Q�[���}�l�[�W���[")]
    private GameManager _gameManager;
    [SerializeField, Tooltip("�v���C���[�̃I�u�W�F�N�g")]
    private GameObject _player;
    [SerializeField, Tooltip("��������E�F�[�u")]
    private GameObject _waveCenter;
    [SerializeField, Tooltip("�E�F�[�u�𐶐�����͈�A")]
    private Transform _muzzleA;
    [SerializeField, Tooltip("�E�F�[�u�𐶐�����͈�B")]
    private Transform _muzzleB;
    [SerializeField, Tooltip("�����_�������̏���")]
    private int _randomNum;
    [SerializeField, Tooltip("�W�����v�̉񐔂ɉ����������̏���")]
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
    /// �����_���Ȉʒu�ɃE�F�[�u�Z���^�[�𐶐�����
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
    /// �v���C���[�̈ʒu�ɃE�F�[�u�Z���^�[�𐶐�����
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
