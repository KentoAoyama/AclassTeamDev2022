using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerController : MonoBehaviour
{
    [Tooltip("�ړ��̑��x")]
    [SerializeField] private float _moveSpeed = 1f;

    [Tooltip("�W�����v���s������")]
    [SerializeField] private float _jumpTime = 3f;

    [Tooltip("�v���C���[�𖳓G�ɂ���f�o�b�O�p�ϐ�")]
    [SerializeField] private bool _isGodMode = false;

    /// <summary>
    /// �W�����v���s�����Ƃ�\�����A�N�e�B�u�v���p�e�B
    /// </summary>
    private ReactiveProperty<bool> _isJump = new ();
    /// <summary>
    /// �W�����v�̉񐔂�\���ϐ�
    /// </summary>
    private int _jumpCount = 0;
    /// <summary>
    /// �Q�[���\�I�[�o�[��\���ϐ�
    /// </summary>
    private bool _isGameOver = false;
    /// <summary>
    /// �v���C���[��RigidBody
    /// </summary>
    private Rigidbody2D _rb;
    /// <summary>
    /// �ړ��̏������`���Ă���N���X
    /// </summary>
    private PlayerMove _playerMove = new ();
    /// <summary>
    /// �W�����v�̏������`���Ă���N���X
    /// </summary>
    private PlayerJump _playerJump = new ();

    /// <summary>
    /// �W�����v���s�����񐔂�\���v���p�e�B
    /// </summary>
    public int JumpCount => _jumpCount;
    /// <summary>
    /// �Q�[���I�[�o�[�ł��邩��\���v���p�e�B
    /// </summary>
    public bool IsGameOver => _isGameOver;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _isJump
            .Skip(1)
            .ThrottleFirst(TimeSpan.FromSeconds(_jumpTime - 1f))
            .Subscribe(_ => _playerJump.Jump(gameObject, _jumpTime))            
            .AddTo(gameObject);
    }

    private void Update()
    {
        _isJump.Value = Input.GetButtonDown("Jump");

        _playerMove.Move(
            _rb,
            _moveSpeed,
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"));
    }
}
