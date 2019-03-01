using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    Vector3 direction;
    Vector3 position;
    public float speed;
    public int bulletDamage = 10;


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
        
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        //direction = transform.forward;



    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);

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
        print(other.name);

        //if (other.gameObject.name == "Cruck(Clone)")
        //{
        //    GetComponent<Enemy1>().TakeDamage(bulletDamage);
        //}

        //if (other.gameObject.name == "Spawner(Clone)")
        //{
        //    GetComponent<HiveScript>().TakeDamage(bulletDamage);
        //}

        Destroy(gameObject);
        if (other.gameObject.tag == "Structure")
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

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position += transform.forward * speed;
        transform.position += direction * speed;

    }
}
