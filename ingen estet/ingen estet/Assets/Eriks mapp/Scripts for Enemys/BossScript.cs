using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {
    public float Timer = 0;
    public GameObject Bullet;
    public GameObject targ; //the enemy's target
    public int Numberofbullets = 0;
    // Use this for initialization
    GameObject[] bullets = new GameObject[10];

    void Start () {

        targ = GameObject.FindGameObjectWithTag("Player");
       // Bullet = GameObject.FindGameObjectWithTag("Bullet");

    }

    // Update is called once per frame
    void Update () {


        Timer += Time.deltaTime;

        if (Numberofbullets == bullets.Length)
        {
            
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].GetComponent<Enemy1>().moveSpeed = 5;
                
            }
            if (Timer >= 5)
            {
                for (int i = 0; i < bullets.Length; i++)
                {
                    Destroy(bullets[i]);
                    Numberofbullets--;
                }
            }

        }
        else
        {


            if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) < 30 && bullets.Length != Numberofbullets)
            {
                if (Timer >= 1)
                {
                    //where it will spawn
                    float x = Random.Range(1f, 3f);
                    int Radom = Random.Range(1, 3);

                    if (Radom == 1)
                    { x *= -1; }

                    float y = Random.Range(1f, 3f);
                    int Subrand = Random.Range(1, 3);
                    if (Subrand == 1)
                    { y *= -1; }

                    bullets[Numberofbullets] = Instantiate(Bullet, transform.position + new Vector3(x, y, 0), Quaternion.identity);
                    bullets[Numberofbullets].GetComponent<Enemy1>().moveSpeed = 0f;
                    Numberofbullets += 1;
                    Timer = 0;
                }
            }

        }

    }
}
