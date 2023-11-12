using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public DeadZoneScript dZ;

    public GameObject gold;
    public float spawnRate;
    public int goldCount;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 1.3f;
        goldCount = 0;
        SpawnGold();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate && dZ.gameActive == true)
        {
            timer = timer + Time.deltaTime;
        }
        else if (timer > spawnRate && goldCount < 10 && dZ.gameActive == true) // && dZ.gameActive == true)
        {
           SpawnGold();
           goldCount += 1;
           timer = 0;
        }
        
    }

    void SpawnGold()
    {
        if (dZ.gameActive)
        {
            Instantiate(gold, transform.position, transform.rotation);
        }
    }
}
