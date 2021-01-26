using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
        	if(GameIsPaused)
        	{
        		Resume();
        	}
        	else
        	{
        		Pause();
        	}
        }
    }

    // Resume
    public void Resume()
    {
    	pauseMenuUI.SetActive(false);
    	Time.timeScale = 1f;
    	GameIsPaused = false;
    }

    // Pause
    void Pause()
    {
    	pauseMenuUI.SetActive(true);
    	Time.timeScale = 0f;
    	GameIsPaused = true;
    }

    public void LoadOptions()
    {
    	Debug.Log("Loading Options..");
    	
    }

    public void Quit()
    {
    	Debug.Log("Quit Game!!");
    	Application.Quit();
    }
}
