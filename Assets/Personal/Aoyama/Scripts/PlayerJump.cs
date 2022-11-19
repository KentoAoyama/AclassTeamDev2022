using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Player�̃W�����v�̏������`����N���X
/// </summary>
public class PlayerJump
{
    /// <summary>
    /// Player�̃W�����v�̏���
    /// </summary>
    public void Jump(GameObject player, float jumpTime)
    {
        Debug.Log("�W�����v�̏������s���܂����B");

        Sequence sequence = DOTween.Sequence();

        sequence.Insert(0f, player.transform.DOScale(2f, jumpTime / 2f).SetEase(Ease.OutCubic));
        sequence.Insert(0.5f, player.transform.DOScale(1f, jumpTime / 2f).SetEase(Ease.InCubic));
        sequence.OnComplete(() => Debug.Log("���n���܂���"));

        sequence.Play();
        
    }
}
