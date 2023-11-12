using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyingObstacleBehavior : MonoBehaviour
{
    private float spd;
    [SerializeField] private Rigidbody2D myBody;
    // Start is called before the first frame update
    void Start()
    {
        spd = Random.Range(6f, 12f)*1.5f; 
    }

    // Update is called once per frame
    void Update()
    {
        myBody.AddForce((Vector2.left * spd)*Time.deltaTime, ForceMode2D.Impulse);
        if(myBody.transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
