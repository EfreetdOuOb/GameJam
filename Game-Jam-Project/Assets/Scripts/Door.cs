using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    GameManager gameManager;
    UIManager uiManager;

     
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        uiManager = FindObjectOfType<UIManager>();
    } 
    private void OnTriggerEnter2D(Collider2D collision)
    {
         
        if (collision.CompareTag("Player"))  
        {
             
            if (uiManager.score >= 3)
            {
                gameManager.EndGame();  
            }
        }
    }
}
