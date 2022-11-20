using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player‚ÌˆÚ“®‚ğŠÇ—‚·‚éƒNƒ‰ƒX
/// </summary>
public class PlayerMove
{
    /// <summary>
    /// Player‚ÌˆÚ“®‚Ìˆ—
    /// </summary>
    public void Move(Rigidbody2D rb, float moveSpeed,float inputX, float InputY)
    {
        rb.velocity = new Vector2(inputX, InputY) * moveSpeed;
    }
}
