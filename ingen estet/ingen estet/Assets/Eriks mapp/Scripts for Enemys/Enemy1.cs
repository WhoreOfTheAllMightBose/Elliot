using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    public GameObject targ; //the enemy's target
    public GameObject[] PrefabDrops;

    public static int Kills = 0;

    public float DistanceToFollow;
    public float moveSpeed; //move speed
    public float rotationSpeed = 5; //speed of turning
    public int EnemyHealth = 3; //Holds the heathtotal of an Enemy

    int dropChance = 7;

    void Start()
    {
        //hämta spelaren och spara i targ
        targ = GameObject.FindGameObjectWithTag("Player");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            print(other.gameObject.name);
            EnemyHealth --;
            //EnemyHealth -= GetComponent<ProjectileScript>().bulletDamage;

        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Projectile")
    //    {
    //        print(collision.gameObject.name);
    //        EnemyHealth -= GetComponent<ProjectileScript>().bulletDamage;

    //    }
    //}

    /// <summary>
    /// om den ska droppa och ifall den ska droppa
    /// </summary>
    void whatDrop()
    {
        int droprate = Random.Range(0, PrefabDrops.Length);

        if (Droprate() && PrefabDrops.Length > -1)
        {
            Instantiate(PrefabDrops[droprate], transform.position, Quaternion.identity); // skapar en av de x antal random prefabs
        }
    }

    /// <summary>
    /// Kollar ifall fieden ska droppa något vid sin död
    /// </summary>
    /// <returns>Om fienden skulle droppa något</returns>
    bool Droprate()
    {
        int droprate = Random.Range(0, 10);

        if (dropChance < droprate) // om chansen att något ska droppa är lägre än ett random nummer mellan 0 och 10;
        {
            return true;
        }

        return false; // ifall dropchans var större än droprate sp ska det inte skapa dett object
    }

    void FixedUpdate()
    {
        //   GameObject.Find("player").GetComponent<Movement>().speed = 4;

        print(EnemyHealth);

        if (EnemyHealth <= 0)
        {
            whatDrop();
            if(RandomEnemy.AmountOfEnemys - 1 > 0)
              RandomEnemy.AmountOfEnemys--;
            Kills++;
            print("Enemy Killed");
            Destroy(this.gameObject);
        }
        

        if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) < DistanceToFollow)
            transform.position = Vector3.MoveTowards(transform.position, targ.transform.position, moveSpeed * 0.01f);
        
    }
}