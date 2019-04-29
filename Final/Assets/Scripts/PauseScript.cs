using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
   
    public static PauseScript instance;
    //This variable is used to keep track if our game is paused or not.
    public static bool gamePaused = false;

    public GameObject pauseMenuPanel;
    public GameObject healthPanel;
    public GameObject gameOverPanel;
    public GameObject continuePanel;

    public void Awake()
    {
        // only keep the first copy of this script around
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        pauseMenuPanel.gameObject.SetActive(false);
        healthPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    //In this method we want to bring up the pause menu and freeze the game.
   public void PauseGame()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        Debug.Log("PauseGame method fired");
    }

    //In this method we remove the pause menu and resume the game.
    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        Debug.Log("ResumeGame method fired");
    }

    public void RestartGame()
    {
        gamePaused = false;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game has Quit");
    }

    public void Continue() {
        continuePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
