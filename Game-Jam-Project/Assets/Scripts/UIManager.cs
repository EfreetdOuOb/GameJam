using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine; 
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    private GameManager gameManager;
     
    public Text scoreText;
    public GameObject gameOverMenu;
    public GameObject gamePauseMenu;

    private int score=0;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        score = 0;
        UpdateScoreText();
        gameOverMenu.SetActive(false);
        gamePauseMenu.SetActive(false);

    } 
    void Update()
    {
        
    }

    public void IncreaseScore(int amount)
    {
        if (gameManager.isGameOver == false)
        {
            score += amount;
            UpdateScoreText();
        }
    }
    void UpdateScoreText()
    {
        scoreText.text = "¤w¦¬¶°: " + score.ToString()+"/3";
        if(score >= 3)
        {
            gameManager.isGameOver = true;
        }
    }

    public void ShowGamePauseMenu()
    {
        gamePauseMenu.SetActive(true);
    }

    public void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
}
