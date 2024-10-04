using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int health;
    [SerializeField] public int MaxHealth = 10;
    /*[SerializeField] public int damage = 10;
    [SerializeField] public float attackCooldown = 20f;
    public float currentCooldown;*/
    public GameObject player;
    public string enemyName;

    // Start is called before the first frame update
    void Start()
    {
        health = MaxHealth;
        //currentCooldown = attackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
        /*if(health > 0) //player.GetComponent<Player>().health > 0 && 
        {
            currentCooldown -= Time.deltaTime;
            if(currentCooldown <= 0)
            {
                Attack();
            }
        } */       
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            TakeDamage(10);
            Destroy(other.gameObject);
            Debug.Log("Enemy hit by bullet");
        }
    }

    public void Attack()
    {
        //player.GetComponent<Player>().TakeDamage(damage);
        //currentCooldown = attackCooldown;
    }
    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        player.GetComponent<Player>().AddPoints(100);
        GameManager.Instance.AddPlushie(enemyName);
        //play death animation
        Destroy(gameObject);
    }


}
