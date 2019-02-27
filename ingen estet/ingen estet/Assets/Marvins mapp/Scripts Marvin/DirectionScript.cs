using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionScript : MonoBehaviour {

    public float Speed;
    Vector3 direction;
    GameObject Player;
    //public Transform target;

    private void Start()
    {
        Player = GameObject.Find("Cube");
        //Vector3 targetDir = target.position - transform.position;
        direction = GetDir();
        //float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
    }

   

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Speed * Time.deltaTime;
       // Vector3 targetDir = target.position - transform.position;
    }

    Vector3 GetDir()
    {
        Vector3 dir = Player.transform.position - transform.position;
        dir.Normalize();
        return dir;
    }
}

