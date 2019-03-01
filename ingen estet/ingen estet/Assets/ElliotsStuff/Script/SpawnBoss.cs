using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject Boss;
    public bool BossIsAcctive = false;


    AudioSource au;
    float dis;
    GameObject player;
    private void Start()
    {
       player =  GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(transform.position,player.transform.position);
        if (Enemy1.Kills > 20 && dis > 30 && !BossIsAcctive)
        {
            Instantiate(Boss);
            BossIsAcctive = true;
            GameObject.FindGameObjectWithTag("Music").GetComponent<audioSwicher>().playing = false;
           // BossIsAcctive = true;
        }
    }
}
