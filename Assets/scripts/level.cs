using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level : MonoBehaviour
{
    [SerializeField] float DelayToLoad = 3f;
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadPlayScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<GameSession>().ResetGame();


    }
    public void LoadGameover()
    {
       StartCoroutine( WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(DelayToLoad);
        SceneManager.LoadScene(2);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
