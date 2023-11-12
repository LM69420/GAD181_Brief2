using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
    public string shootKey = "space";
    public static UnityEvent shoot = new UnityEvent();
    public float shootDelay = 1;
    public float lastShootTime;

    public void Update()
    {
        if (Input.GetKeyDown(shootKey) & Time.time >= lastShootTime + shootDelay)
        {
            shoot.Invoke();
            lastShootTime = Time.time;
        }
    }

}
