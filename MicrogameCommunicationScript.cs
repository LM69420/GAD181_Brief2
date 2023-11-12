using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrogameCommunicationScript : MonoBehaviour
{
    public delegate void GameLose();
    public static event GameLose GameLost;
    public delegate void GameWin();
    public static event GameWin GameWon;
}
