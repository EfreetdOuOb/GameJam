using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 

    public UIManager uiManager;
     
    public bool isPaused = false;
    public bool isGameOver = false;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        Time.timeScale = 1;
    }

    
    void Update()
    {
        if (isGameOver == true)
        {
            EndGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                PauseGame();

            }
            else
            {
                ResumeGame();
            }

        }
    }


    

    public void PauseGame()
    {
        Time.timeScale = 0;
        uiManager.ShowGamePauseMenu();
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        uiManager.gameOverMenu.SetActive(false);
        uiManager.gamePauseMenu.SetActive(false);
        isPaused = false;

    }

    public void EndGame()
    { 
        uiManager.ShowGameOverMenu(); 
        Time.timeScale = 0; 
    }

    public void RestartGame()
    {
        // ���J��e�����H���s�}�l 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()//��^�D�e��
    {
        SceneManager.LoadScene("MainMenu");
    }

    


}
