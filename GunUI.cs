using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunUI : MonoBehaviour
{
    // assign
    public Scrollbar target;
    public Scrollbar aim;
    public TextMeshProUGUI timerT;
    public float changeRate = 1f;
    public float changeAmount = 0.1f;
    public float range = 0.2f;

    // ignore
    CanvasGroup group;
    float lastChange;
    public bool show;
    float change;
    public float targetValue;
    public float aimValue;

    // Start is called before the first frame update
    void Start()
    {
        // sets up the components
        group = GetComponent<CanvasGroup>();
        group.alpha = 0;
        timerT.transform.GetComponentInParent<CanvasGroup>().alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // plays if shown
        if (show)
        {
            // sets the values correctly
            if (EnemyController.me.enemies[EnemyController.me.currentEnemy])
                timerT.text = EnemyController.me.enemies[EnemyController.me.currentEnemy].currentTimer.ToString();
            timerT.transform.GetComponentInParent<CanvasGroup>().alpha = Mathf.Lerp(timerT.transform.GetComponentInParent<CanvasGroup>().alpha, 1, 0.1f);
            group.alpha = Mathf.Lerp(group.alpha, 1, 0.05f);
            // moves the aimer up and down
            if (Time.time >= lastChange + changeRate)
            {
                aimValue += change;
                aimValue = Mathf.Clamp(aimValue, 0f, 1f);
                lastChange = Time.time;
                if (aimValue == 1)
                    change = -changeAmount;
                if (aimValue == 0)
                    change = changeAmount;
            }
            aim.value = aimValue;
        }
        else
        {
            // hides when hidden
            timerT.transform.GetComponentInParent<CanvasGroup>().alpha = Mathf.Lerp(timerT.transform.GetComponentInParent<CanvasGroup>().alpha, 0, 0.1f);
            group.alpha = Mathf.Lerp(group.alpha, 0, 0.4f);
        }
    }

    // sets up the Ui values
    public void SetUp()
    {
        targetValue = (float)Random.Range(0f, 1f);
        target.value = targetValue;
        aimValue = 0;
        aim.value = aimValue;
        lastChange = Time.time;
        change = changeAmount;
    }

    // when the weapon is fired, check if the player hits the target
    public void Fire()
    {
        if (Mathf.Abs(aimValue - targetValue) <= range)
        {
            EnemyController.me.enemies[EnemyController.me.currentEnemy].Hit();
            FindObjectOfType<Gun>().lastFired = Time.time + 0.5f;
            ChangeShow(false);
        }
    }

    // Changes the visibility of the Ui
    public void ChangeShow(bool New)
    {
        show = New;
        if (show)
            SetUp();
    }
}
