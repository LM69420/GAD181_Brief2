using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public delegate void GameLose();
    public static event GameLose GameLost;

    // assign
    public Animator gunAni;
    public float fireRate = 1;
    public GunUI ui;

    // ignore
    public bool ready;
    public bool readying;
    public float lastFired;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribes the input event to the right button
        InputController.shoot.AddListener(RecieveInput); // idiot replace this with you're own input controller. Thx
    }

    // Update is called once per frame
    void Update()
    {
        // Adds shoot speed
        if (Time.time >= lastFired + fireRate)
            lastFired = 0;
    }

    // Pulls the weapon out
    public void ReadyWeapon()
    {
        gunAni.CrossFadeInFixedTime("UnHolster", 0.1f);
        StartCoroutine(WaitReady());
    }
    // Waits for the weapon to be pulled out and shows the Ui
    public IEnumerator WaitReady()
    {
        readying = true;
        yield return new WaitForSeconds(0.25f);
        ui.ChangeShow(true);
        yield return new WaitForSeconds(0.25f);
        ready = true;
        readying = false;
        lastFired = Time.time;
    }
    // Fires the weapon
    public void Fire()
    {
        gunAni.CrossFadeInFixedTime("Fire", 0.1f);
        lastFired = Time.time;
        ui.Fire();
    }

    // holsteres the weapon on hit
    public void Hit()
    {
        gunAni.CrossFadeInFixedTime("Holstered", 0.1f);
        // idiot put something here please for loosing
        Debug.Log("PLAYER WAS SHOT");
        GameLost?.Invoke();
    }

    // recieves the input and fires the weapon
    public void RecieveInput()
    {
        if (lastFired == 0)
            Fire();
    }
}
