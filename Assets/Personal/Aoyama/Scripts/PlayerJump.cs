using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Playerのジャンプの処理を定義するクラス
/// </summary>
public class PlayerJump
{
    /// <summary>
    /// Playerのジャンプの処理
    /// </summary>
    public void Jump(GameObject player, float jumpTime)
    {
        Debug.Log("ジャンプの処理を行いました。");

        Sequence sequence = DOTween.Sequence();

        sequence.Insert(0f, player.transform.DOScale(2f, jumpTime / 2f).SetEase(Ease.OutCubic));
        sequence.Insert(0.5f, player.transform.DOScale(1f, jumpTime / 2f).SetEase(Ease.InCubic));
        sequence.OnComplete(() => Debug.Log("着地しました"));

        sequence.Play();
        
    }
}
