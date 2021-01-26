using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public static GameOver Instance { set; get; }

	public GameObject gameOverUI;

	private void Start()
    {
        Instance = this;
    }

    public void GameOverMenu()
    {
    	gameOverUI.SetActive(true);

    	Time.timeScale = 0f;
    }

    public void Quit()
    {
    	Debug.Log("Quit Game!!");
    	Application.Quit();
    }

    public void MainMenu()
    {
    	gameOverUI.SetActive(false);
    	Time.timeScale = 1f;
    	BoardManager.Instance.EndGame();
    	SceneManager.LoadScene(0);
    }
}
