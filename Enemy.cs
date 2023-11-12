using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 1;
    public float timer = 3;
    // assign
    public Animator ani;

    // ignore
    public bool readying;
    public bool ready;
    public bool dying;
    public float health;
    public float currentTimer;
    public GunUI gunUI;

    // Start is called before the first frame update
    void Start()
    {
        // sets up
        health = maxHealth;
        gunUI = FindObjectOfType<GunUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When the enemy is hit
    public void Hit()
    {
        health -= 1;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health == 0)
            Die();
    }

    // when the enemy dies
    public void Die()
    {
        dying = true;
        ani.CrossFadeInFixedTime("Die", 0.1f);
        StartCoroutine(WaitDie());
    }
    // waits when die to destroy the object after a time
    public IEnumerator WaitDie()
    {
        yield return new WaitForSeconds(0.1f);
        EnemyController.me.NextEnemy();
        Destroy(gameObject, 1f);
    }

    // fires the enemy gun
    public void Fire()
    {
        if (dying)
            return;
        ani.CrossFadeInFixedTime("Fire", 0.1f);
        FindObjectOfType<Gun>().lastFired = Time.time + 5;
        gunUI.ChangeShow(false);
        StartCoroutine(WaitFire());
    }
    // waits upon fire to register hit on player
    public IEnumerator WaitFire()
    {
        yield return new WaitForSeconds(0.1f);
        FindObjectOfType<Gun>().Hit();
    }

    // waits for the enemy to become ready to attack
    public IEnumerator WaitReady()
    {
        yield return new WaitForSeconds(0.1f);
        ready = true;
        readying = false;
        if (!FindObjectOfType<Gun>().ready)
            FindObjectOfType<Gun>().ReadyWeapon();
        else
            gunUI.ChangeShow(true);
        StartCoroutine(Timer());
    }
    // waits for the enemy to shoot
    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        currentTimer -= 1;
        if (currentTimer == 0)
            Fire();
        else
            StartCoroutine(Timer());
    }
    // readys the enemy
    public void Ready()
    {
        readying = true;
        ani.CrossFadeInFixedTime("Ready", 0.1f);
        currentTimer = timer;
        StartCoroutine(WaitReady());
    }
}
