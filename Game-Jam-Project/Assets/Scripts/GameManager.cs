using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{ 

    public UIManager uiManager;
     
    public bool isPaused = false;
    public bool isGameOver = false;
    public bool isTouchEndDoor = false;
     

    GameObject boxY, boxP, boxG;
    GameObject btnY, btnP, btnG;
    GameObject doorY, doorP, doorG;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        playerController = FindObjectOfType<PlayerController>();
        Time.timeScale = 1;

        boxY = GameObject.Find("Box(Yellow)");
        boxP = GameObject.Find("Box (Purple)");
        boxG = GameObject.Find("Box (Green)");

        btnY = GameObject.Find("Button (Yellow)");
        btnP = GameObject.Find("Button (Purple)");
        btnG = GameObject.Find("Button(Green)");

        doorY = GameObject.Find("Door(Yellow)");
        doorP = GameObject.Find("Door (Green)");
        doorG = GameObject.Find("Door (Purple)");
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


    public void DestroyButtonAndDoor(string buttonName, string doorName)
    {
        GameObject button = GameObject.Find(buttonName);
        GameObject door = GameObject.Find(doorName);

        if (button != null)
        {
            Destroy(button);
        }
        else
        {
            Debug.LogError(buttonName + " not found!");
        }

        if (door != null)
        {
            Destroy(door);
        }
        else
        {
            Debug.LogError(doorName + " not found!");
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
        // 載入當前場景以重新開始 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()//返回主畫面
    {
        SceneManager.LoadScene("MainMenu");
    }

    


}
