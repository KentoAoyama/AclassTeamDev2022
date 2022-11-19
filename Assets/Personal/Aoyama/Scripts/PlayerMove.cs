using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerの移動を管理するクラス
/// </summary>
public class PlayerMove
{
    /// <summary>
    /// Playerの移動の処理
    /// </summary>
    /// <param name="rb"></param>
    /// <param name="inputX"></param>
    /// <param name="InputY"></param>
    public void Move(Rigidbody2D rb, float moveSpeed,float inputX, float InputY)
    {
        rb.velocity = new Vector2(inputX, InputY) * moveSpeed;
    }
}
