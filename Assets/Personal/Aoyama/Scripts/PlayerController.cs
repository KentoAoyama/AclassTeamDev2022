using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;


public class PlayerController : MonoBehaviour
{
    [Tooltip("�ړ��̑��x")]
    [SerializeField] private float _moveSpeed = 1f;

    [Tooltip("�W�����v���s������")]
    [SerializeField] private float _jumpTime = 3f;

    [Tooltip("�ڐG����Wave�I�u�W�F�N�g�̃^�O�̖��O")]
    [TagName, SerializeField] private string _waveTagName;

    [Tooltip("�v���C���[�𖳓G�ɂ���f�o�b�O�p�ϐ�")]
    [SerializeField] private bool _isGodMode = false;

    /// <summary>
    /// �W�����v���s�����Ƃ�\�����A�N�e�B�u�v���p�e�B
    /// </summary>
    private BoolReactiveProperty _isJump = new();
    /// <summary>
    /// �W�����v���ł��邱�Ƃ�\���ϐ�
    /// </summary>
    private bool _isJumping = false;
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
            .ThrottleFirst(TimeSpan.FromSeconds(_jumpTime))
            .Subscribe(_ => Jump(gameObject, _jumpTime))
            .AddTo(gameObject);
    }

    private void Update()
    {
        _isJump.Value = Input.GetButtonDown("Jump");

        Move(_rb, 
            _moveSpeed,
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"));
    }

    /// <summary>
    /// Player�̃W�����v�̏���
    /// </summary>
    public void Jump(GameObject player, float jumpTime)
    {
        _isJumping = true;
        Debug.Log($"isJumping = {_isJumping}");

        Sequence sequence = DOTween.Sequence();
        float time = jumpTime / 2f;

        sequence.Insert(0f, player.transform.DOScale(2f, time).SetEase(Ease.OutCubic));
        sequence.Insert(time, player.transform.DOScale(1f, time).SetEase(Ease.InCubic));
        sequence.OnComplete(() => _isJumping = false);
        sequence.OnKill(() => Debug.Log($"isJumping = {_isJumping}"));

        sequence.Play();
    }

    /// <summary>
    /// Player�̈ړ��̏���
    /// </summary>
    public void Move(Rigidbody2D rb, float moveSpeed, float inputX, float InputY)
    {
        rb.velocity = new Vector2(inputX, InputY) * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_waveTagName)
            && !_isJumping
            && !_isGodMode)
        {
            _isGameOver = true;

            Debug.Log("GameOver");
        }
    }
}
