using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;


public class PlayerController : MonoBehaviour
{
    [Tooltip("移動の速度")]
    [SerializeField] private float _moveSpeed = 1f;

    [Tooltip("ジャンプを行う時間")]
    [SerializeField] private float _jumpTime = 3f;

    [Tooltip("接触するWaveオブジェクトのタグの名前")]
    [TagName, SerializeField] private string _waveTagName;

    [Tooltip("死亡時に変化する色")]
    [SerializeField] private Color _deathColor;

    [Tooltip("プレイヤーを無敵にするデバッグ用変数")]
    [SerializeField] private bool _isGodMode = false;

    /// <summary>
    /// ジャンプを行うことを表すリアクティブプロパティ
    /// </summary>
    private BoolReactiveProperty _isJump = new();
    /// <summary>
    /// ジャンプ中であることを表す変数
    /// </summary>
    private bool _isJumping = false;
    /// <summary>
    /// ジャンプの回数を表す変数
    /// </summary>
    private int _jumpCount = 0;
    /// <summary>
    /// ゲーム―オーバーを表す変数
    /// </summary>
    private bool _isGameOver = false;
    /// <summary>
    /// プレイヤーのRigidBody
    /// </summary>
    private Rigidbody2D _rb;
    /// <summary>
    /// プレイヤーのSpriteRenderer
    /// </summary>
    private SpriteRenderer _sr;
    /// <summary>
    /// プレイヤーのAudioSource
    /// </summary>
    private AudioSource _as;

    /// <summary>
    /// ジャンプを行った回数を表すプロパティ
    /// </summary>
    public int JumpCount => _jumpCount;
    /// <summary>
    /// ゲームオーバーであるかを表すプロパティ
    /// </summary>
    public bool IsGameOver => _isGameOver;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _as = GetComponent<AudioSource>();

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
    /// Playerのジャンプの処理
    /// </summary>
    public void Jump(GameObject player, float jumpTime)
    {
        _isJumping = true;
        Debug.Log($"isJumping = {_isJumping}");

        _as.Play();
        float time = jumpTime / 2f;
        Sequence sequence = DOTween.Sequence();

        sequence.Insert(0f, player.transform.DOScale(2f, time).SetEase(Ease.OutCubic));
        sequence.Insert(time, player.transform.DOScale(1f, time).SetEase(Ease.InCubic));
        sequence.OnComplete(() => _isJumping = false);
        sequence.OnKill(() => _jumpCount++);

        sequence.Play();
    }

    /// <summary>
    /// Playerの移動の処理
    /// </summary>
    public void Move(Rigidbody2D rb, float moveSpeed, float inputX, float InputY)
    {
        if (!_isGameOver)
        {
            rb.velocity = new Vector2(inputX, InputY) * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_waveTagName)
            && !_isJumping
            && !_isGodMode
            && !_isGameOver)
        {
            _isGameOver = true;
            _sr.DOColor(_deathColor, 1f);

            Debug.Log("GameOver");
        }
    }
}
