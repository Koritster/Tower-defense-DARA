using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripter : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeScene(int nScene)
    {
        SceneManager.LoadScene(nScene);
    }
}
