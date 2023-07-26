using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    [SerializeField] GameObject RestartMenu;

    public void OpenRestartMenu()
    {
        RestartMenu.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SwitchToMainMenu()
    {
        SceneManager.LoadScene(0);
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
