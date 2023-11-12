using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainPlayerController : MonoBehaviour
{ 
    public delegate void GameLose();
    public static event GameLose GameLost;
    public delegate void GameWin();
    public static event GameWin GameWon;

    private float timer;
    [SerializeField] private GameDirectorScript gameDirector;

    private bool grounded;
    [SerializeField] private Rigidbody2D myBody;

    private void OnEnable()
    {
        KeyDirectorScript.spacePressed += SpacePressed;
    }

    private void OnDisable()
    {
        KeyDirectorScript.spacePressed -= SpacePressed;
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        
        if(timer>=6)
        {
            GameWon?.Invoke();
        }
    }

    void SpacePressed()
    {
    
        if(grounded)
        {
            myBody.AddForce(Vector2.up*40f,ForceMode2D.Impulse); 
            grounded = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "TrainObstacle")
        {
            Debug.Log("COLLISION with TRAIN OBSTACLE");
            GameLost?.Invoke(); 
        }
    }
}
