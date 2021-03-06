﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemy : MonoBehaviour
{
    public GameObject[] Enemys;
    public float Distance;

    GameObject player;

    float timer;
    float distance;
    int randEnemy;
    int randomAmount;
    int spawnrangeX;
    int spawnrangeY;
    bool firstTime = true;

    public static int AmountOfEnemys = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //StartSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance < Distance && AmountOfEnemys < 10)
        {
            timer += Time.deltaTime * AmountOfEnemys;

            if (timer > 5 || firstTime)
            {
                firstTime = false;
                spawnLaiter();
                timer = 0;
            }
        }
      
    }

    void StartSpawner()
    {
        randEnemy = Random.Range(0, Enemys.Length);
        randomAmount = Random.Range(3, 5);

        for (int i = 0; i < randomAmount; i++)
        {
            Instantiate(Enemys[randEnemy], transform.position, Quaternion.identity);
        }
    }


    void spawnLaiter()
    {
        randEnemy = Random.Range(0, Enemys.Length);
        spawnrangeX = Random.Range(-8, 8);
        spawnrangeY = Random.Range(-8, 8);
        Vector3 spawnpoint = new Vector3(transform.position.x + spawnrangeX, transform.position.y + spawnrangeY, 0);

        if (Enemys[randEnemy].name != "Spawner")
            randomAmount = Random.Range(3, 5);
        else
            randomAmount = 1;

        for (int i = 0; i < randomAmount; i++)
        {
            Instantiate(Enemys[randEnemy],spawnpoint, Quaternion.identity);
        }

        AmountOfEnemys++;

    }
}
