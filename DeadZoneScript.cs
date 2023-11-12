using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneScript : MonoBehaviour
{
    public bool gameActive;
    public GameObject canvas;
    public delegate void GameLose();
    public static event GameLose GameLost;

    void Start()
    {
        gameActive = true;
    }

    // This is where the player will lose by letting one of the Gold pieces slip past them.
    public void OnTriggerEnter2D(Collider2D collision)
    {
        ItsJover();
        GameLost();
        //GameOverScreen();
    }

    public void ItsJover()
    {
        Debug.Log("Game Over!");
        gameActive = false;
    }

    public void SetGameActive(bool newState)
    {   
         gameActive = false;
    }

    public void GameOverScreen()
    {
        if (canvas != null)
        {
            canvas.SetActive(true);
        }
        else
        {
            Debug.Log("No canvas assigned");
        }
    }
}
