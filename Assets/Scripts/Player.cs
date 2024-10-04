using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int points = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {   
        health -= damage;
        Debug.Log("Player took damage, Current health: " + health);
        if(health <= 0)
        {
            //Die();
            Debug.Log("Player died");
        }
    }

    public void AddPoints(int point)
    {
        points += point;
    }
}
