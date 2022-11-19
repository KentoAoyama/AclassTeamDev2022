using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerController : MonoBehaviour
{
    [Tooltip("移動の速度")]
    [SerializeField] private float _moveSpeed = 1f;

    [Tooltip("ジャンプを行う時間")]
    [SerializeField] private float _jumpTime = 3f;

    [Tooltip("プレイヤーを無敵にするデバッグ用変数")]
    [SerializeField] private bool _isGodMode = false;

    /// <summary>
    /// ジャンプを行うことを表すリアクティブプロパティ
    /// </summary>
    private ReactiveProperty<bool> _isJump = new ();
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
    /// 移動の処理を定義しているクラス
    /// </summary>
    private PlayerMove _playerMove = new ();
    /// <summary>
    /// ジャンプの処理を定義しているクラス
    /// </summary>
    private PlayerJump _playerJump = new ();

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
