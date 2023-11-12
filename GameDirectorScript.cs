using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.SceneManagement;
using UnityEngine;

public class GameDirectorScript : MonoBehaviour
{
   [SerializeField] private GameObject[] prefDetector;
    [SerializeField] private GameObject[] prefabList;
    [SerializeField] private TextMeshProUGUI txt;
    private GameObject currentLevelPrefab;
    private float timer;
    private string state;
    [SerializeField] private int currentGame;

 

    private void OnEnable()
    {
        MicrogameCommunicationScript.GameWon += WonGame;
        MicrogameCommunicationScript.GameLost += LostGame;
    }

    private void OnDisable()
    {
        MicrogameCommunicationScript.GameWon -= WonGame;
        MicrogameCommunicationScript.GameLost -= LostGame;
    }
    // Start is called before the first frame update
    void Start()
    {
        state = "menu";
        timer = 0;
        txt.text = "Whirlwind West!\na game by Ashton E., Juan B., Liam M. and Nick C.\n\n\n<SPACE> to start\n<ESCAPE> to exit";
    }

    // Update is called once per frame
    void Update()
    {

        if (state == "menu")
        {
            if(Input.GetKeyDown("space"))
            {
                state = "playing";
                RollGames();
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        if (timer > 0)
        {
            timer -= 1 * Time.deltaTime;
        }

        if (timer <= 0)
        {
            switch (state)
            {
                case "lost":
                    state = "menu";
                    txt.text = "Whirlwind West!\na game by Ashton E., Juan B., Liam M. and Nick C.\n\n\n<SPACE> to start\n<ESCAPE> to exit";
                    break;

                case "won":
                    if (currentGame <= prefabList.Length - 1)
                    {
                        state = "playing";
                        RollGames();
                    }
                    else
                    {
                        state = "gigawin";
                        timer = 5;
                        txt.text = "Heist: COMPLETE!\nWell done!";
                    }
                    break;

                case "gigawin":
                    {
                        state = "menu";
                        txt.text = "Whirlwind West!\na game by Ashton E., Juan B., Liam M. and Nick C.\n\n\n<SPACE> to start\n<ESCAPE> to exit";
                    }
                    break;
            }
        }

    }

    void WonGame()
    {
        Destroy(currentLevelPrefab);
        currentLevelPrefab = null;
        state = "won";
        timer = 3;
        txt.text = "You WIN!!!";
    }

    void LostGame()
    {
        Destroy(currentLevelPrefab); 
        currentLevelPrefab = null;
        state = "lost";
        timer = 3;
        txt.text = "You LOSE!!!";
    }

    void RollGames()
    {
        // Randomly choose and instantiate a game level (if list is not empty)
        if (prefabList != null)
        {
            // Randomly generate number within level prefab range
            int roll;
            roll = UnityEngine.Random.Range(0, prefabList.Length - 1);
            roll = 0;
            roll = currentGame;
            // Store current level as variable
            currentLevelPrefab = Instantiate(prefabList[roll]);
            currentLevelPrefab.transform.position = new Vector3(0, 0, 0);
            currentGame++;
            Sub(roll);
        }
        else
        {
            Debug.Log("Prefab list empty! Assign level prefabs :)");
        }
    }

    void Sub(int gameId)
    {
        switch (gameId) {


            case 0:
        Debug.Log("I'm subbed!");
        TrainPlayerController.GameWon += WonGame;
        TrainPlayerController.GameLost += LostGame;
                txt.text = "Press <SPACE> to\nJUMP OVER obstacles!";
                break;

            case 1:
                Debug.Log("I'm subbed!");
                TimerScript.GameWon += WonGame;
                DeadZoneScript.GameLost += LostGame;
                txt.text = "Use the <ARROWS> to\nCATCH the Gold!";
                break;

            case 2:
                Debug.Log("I'm subbed!");
                EnemyController.GameWon += WonGame;
                Gun.GameLost += LostGame;
                txt.text = "Press <SPACE> to\nSHOOT the Lawmen!";
                break;

    }
    }
}
