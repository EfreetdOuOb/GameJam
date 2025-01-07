using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    GameManager gameManager;

     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.PlayerScored(1);
        }
    }
}
