using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GoldScript : MonoBehaviour
{
    private Rigidbody2D goldRigidbody;
    private float goldThrowPower;

    //private int[] xValues = { -1, 1 };
    private int[] yValues = {  1, 2, 3, };

    //private int newX;
    private int newY;

    void Start()
    {
       goldRigidbody = GetComponent<Rigidbody2D>();
       goldThrowPower = 5.5f;
       GoldThrow();
    }

    void GoldThrow()
    {
        Debug.Log("Toss 'em up!");

        //newX = xValues[Random.Range(0, 2)];
        newY = yValues[Random.Range(0, 3)];

        goldRigidbody.velocity = new Vector2(-1, newY) * goldThrowPower;      
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Gold collided with grabber");
        GoldDelete();
    }

    public void GoldDelete()
    {
        Destroy(gameObject);
    }
}
