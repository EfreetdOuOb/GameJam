using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Button (Yellow)")
        {
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null)
            {
                gameManager.DestroyButtonAndDoor("Button (Yellow)", "Door(Yellow)");
            }
        }
        if (collision.gameObject.name == "Button (Purple)")
        {
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null)
            {
                gameManager.DestroyButtonAndDoor("Button (Purple)", "Door (Purple)");
            }
        }
        if (collision.gameObject.name == "Button(Green)")
        {
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null)
            {
                gameManager.DestroyButtonAndDoor("Button(Green)", "Door (Green)");
            }
        }

    }
}
