using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField] FadeSystem _fadeSystem;

    private void Start()
    {
        _fadeSystem.StartFadeIn();
    }

    public void FadeOut(string nextScene)
    {
        _fadeSystem.StartFadeOut(nextScene);
    }
}
