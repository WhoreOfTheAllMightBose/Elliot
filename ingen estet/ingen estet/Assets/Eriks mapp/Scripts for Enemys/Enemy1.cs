using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    public GameObject targ; //the enemy's target
 
    public float moveSpeed; //move speed
    public float rotationSpeed = 5; //speed of turning
    public int EnemyHealth = 3; //Holds the heathtotal of an Enemy

    void Start()
    {
        //hämta spelaren och spara i targ
        targ = GameObject.FindGameObjectWithTag("Player");
        RandomEnemy.AmountOfEnemys++;
    
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
         //   EnemyHealth -= bulletDamage;

        }
    }

    void FixedUpdate()
    {
        //   GameObject.Find("player").GetComponent<Movement>().speed = 4;

        if (EnemyHealth <= 0)
        {
            RandomEnemy.AmountOfEnemys--;
            Destroy(gameObject);
            print("Enemy Killed");
        }

        //print(EnemyHealth);

        
        

        if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) < 5)
            transform.position = Vector3.MoveTowards(transform.position, targ.transform.position, moveSpeed * 0.01f);
        
    }
}