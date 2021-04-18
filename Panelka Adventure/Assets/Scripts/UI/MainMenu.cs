using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitGame() {
        Debug.Log("Quit!!!");
        Application.Quit();
    }

    public void PlayScane() {
        SceneManager.LoadScene(sceneBuildIndex:1);
    }

}
