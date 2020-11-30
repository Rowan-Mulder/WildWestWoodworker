﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealthpoints = 10;
    public int currentHealthpoints = 10;
    public bool dead = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateHealth()
    {
        // May not be needed (yet)
    }

    // Enemy gets shot
    public void Damage(int damage)
    {
        if ((currentHealthpoints -= damage) <= 0)
        {
            currentHealthpoints = 0;
            Death();
        }

        UpdateHealth();
    }

    void Death()
    {
        // Activate death animation and destroy current object after some time for performance?

        dead = true;

        Destroy(gameObject);
    }

    void Revive()
    {
        dead = false;
        currentHealthpoints = maxHealthpoints;
        UpdateHealth();
    }
}