using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnRetryButtonClick()
    {
        // TODO
        Debug.Log("Play");
        SceneManager.LoadScene("Game");
    }
    public void OnPlayButtonClick()
    {
        // TODO
        Debug.Log("Play");
        SceneManager.LoadScene("Game");
    }
    public void OnExitButtonPress()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}