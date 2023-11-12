using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public delegate void GameWin();
    public static event GameWin GameWon;
    public static EnemyController me;
    // assign
    public Enemy[] enemies;

    // ignore
    public int currentEnemy;

    private void Awake()
    {
        me = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        // sets up the first enemy
        enemies[currentEnemy].Ready();
    }

    // Switches to next enemy
    public void NextEnemy()
    {
        if(currentEnemy == enemies.Length - 1)
        {
            // idiot put something here please for winning
            Debug.Log("BANDITOS ELIMINATED");
            GameWon?.Invoke();
        }
        else
        {
            currentEnemy += 1;
            enemies[currentEnemy].Ready();
        }
    }
}
