using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour

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
