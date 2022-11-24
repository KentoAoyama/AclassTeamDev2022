using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    [SerializeField] string _startSceneName;
    [SerializeField] string _gameSceneName;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameSceneChange();
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            StartSceneChange();
        }
    }
    public void StartSceneChange()
    {
        SceneManager.LoadScene(_startSceneName);
    }
    public void GameSceneChange()
    {
        SceneManager.LoadScene(_gameSceneName);
    }

}
