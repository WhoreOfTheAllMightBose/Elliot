using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveScript : MonoBehaviour {
        static int Timer = 0;
    public int EnemyHealth = 10; //Holds the heathtotal of an Enemy
    public GameObject Cruck; //Object it will create
	// Use this for initialization
	void Start () {

	}

    public void TakeDamage(int dmg)
    {
        EnemyHealth -= dmg;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            EnemyHealth -= 1;

        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        //this will create an obect every 90sec
        Timer += 1;

        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
            print("Enemy Killed");

        }

        if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) < 5)
        {
        if (Timer >= 90 )
        {
                //where it will spawn
             float x =   Random.Range(1f, 3f);
                int Radom = Random.Range(1, 3);

                if(Radom == 1)
                { x *= -1; }

                float y = Random.Range(1f, 3f);
                int Subrand = Random.Range(1, 3);
                if (Subrand == 1)
                { y *= -1; }

                GameObject Hive = Instantiate(Cruck,transform.position + new Vector3(x,y,0), Quaternion.identity);
            Timer = 0;
        }
        }

      //  print(EnemyHealth);
    }
}
