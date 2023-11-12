using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDirectorScript : MonoBehaviour
{

    public delegate void SpaceCheck();
    public static event SpaceCheck spacePressed;
    public delegate void LeftCheck();
    public static event LeftCheck leftPressed;
    public delegate void RightCheck();
    public static event RightCheck rightPressed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown("space") && spacePressed!= null)
        {
            spacePressed();
        }

        if (Input.GetKeyDown("left") && leftPressed != null)
        {
            leftPressed();
        }

        if (Input.GetKeyDown("right") && rightPressed != null)
        {
            rightPressed();
        }
    }
}
