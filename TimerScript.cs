using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public DeadZoneScript dZ;
    public GoldScript gold;
    public delegate void GameWin();
    public static event GameWin GameWon;

    public float timeStart = 10;
    public Text textBox;

    private void Start()
    {
        textBox.text = timeStart.ToString();
    }

    // Here is where the player will win by running down the timer.
    private void Update()
    {
        if (timeStart > 0)
        {
            timeStart -= Time.deltaTime;
            textBox.text = Mathf.Round(timeStart).ToString();
        }
        
        if (timeStart <= 0)
        {
            dZ.SetGameActive(false);
            Debug.Log("Time Up Idiot");
            GameWon();
        }
    }
}
