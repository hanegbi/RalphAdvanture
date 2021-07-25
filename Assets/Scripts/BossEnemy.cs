using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEnemy : RangedBlueCopter
{


    public GameObject healthBar;
    public Slider slider;

    void Start()
    {
        Debug.Log(health);
        healthBar.SetActive(true);
        slider = FindObjectOfType<Slider>();
        slider.maxValue = health;
        slider.value = health;
    }

    public override void TakeDamage(int amount)
    {
        health -= amount;
        slider.value = health;
        if (health <= 0)
        {

            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Instantiate(deathSound, transform.position, transform.rotation);
            Destroy(this.gameObject);
            healthBar.SetActive(false);

        }
    }

}
