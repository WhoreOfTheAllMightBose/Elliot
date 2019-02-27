﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    Vector3 direction;
    Vector3 position;
    public float speed;


    public Vector2 Direction
    {
        set {
            if (value == Vector2.zero)
                direction.x = 1;
            else
                direction = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        
        GetComponent<Rigidbody2D>().AddForce(transform.forward * speed);
        //direction = transform.forward;



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.tag == "Structure")
        {
            //Vector3 test1 = new Vector3(transform.forward.x, 0, transform.forward.z);
            //// Vector3 test2 = new Vector3(-transform.forward.x, 0, transform.forward.z);

        
            ////direction.z += -1;
            ////direction.x += -1;

            //float A = 1 / Mathf.Tan(test1.z / test1.x);



            ////Vector3 test2 = new Vector3(transform.forward.x - A, 0, transform.forward.z - A);

            ////test1.z = Mathf.Cos(-A);
            ////test1.x = Mathf.Sin(-A);


            ////if (transform.forward.x < transform.forward.z)
            ////{
            ////    GetComponent<Rigidbody>().AddForce(test2 * speed);
            ////}

            ////  if (transform.forward.z < transform.forward.x)

            //GetComponent<Rigidbody>().AddForce(transform.forward * speed);


        }
    }
    private void OnTriggerEnter(Collider other)
    {


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position += transform.forward * speed;
        transform.position += direction * speed;

    }
}
