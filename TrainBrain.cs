using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainBrain : MonoBehaviour
{
    private float timer;
    [SerializeField] private GameObject pref;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= (1 * Time.deltaTime);
        if (timer <= 0)
        {
            var _y = new Vector2(10f, Random.Range(-2.5f, -1.5f));
            timer = Random.Range(1f, 1.4f);
            Instantiate(pref,_y, Quaternion.identity );
        }
        
    }
}
