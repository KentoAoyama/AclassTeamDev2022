using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player�̈ړ����Ǘ�����N���X
/// </summary>
public class PlayerMove
{
    /// <summary>
    /// Player�̈ړ��̏���
    /// </summary>
    public void Move(Rigidbody2D rb, float moveSpeed,float inputX, float InputY)
    {
        rb.velocity = new Vector2(inputX, InputY) * moveSpeed;
    }
}
