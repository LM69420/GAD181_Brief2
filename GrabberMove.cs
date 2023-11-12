using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberMove : MonoBehaviour
{
    public DeadZoneScript dZ;

    public int grabberSpeed;
    public float wallZoneLeft = -10;
    public float wallZoneRight = 7;

    // Start is called before the first frame update
    void Start()
    {
        grabberSpeed = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > wallZoneLeft)
        {

            transform.Translate(Vector3.left * grabberSpeed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < wallZoneRight)
        {

            transform.Translate(Vector3.right * grabberSpeed * Time.deltaTime);

        }
    }
}
