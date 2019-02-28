using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    Vector3 direction;
    public float speed;
    bool Falling = false;
    public GameObject Projectile;
    public Transform shooter;
    public float ScaleChange = 1;
    public float jump;
    float Horizontal;
    float Vertical;
    float BulletCd = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PowerUp")
        {
            print("Spelaren krockade med " + other.name);
            Destroy(other.gameObject);
        }
        if (other.tag == "Power")
        {
            ScaleChange = 4;
            Destroy(other.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = GetComponent<Movement>().horizontal;
        float vertical = GetComponent<Movement>().vertical;

        if (horizontal != 0 || vertical != 0)
        {
            Horizontal = 0;
            Vertical = 0;
        }

        if (GetComponent<Movement>().horizontal != 0)
        {
            Horizontal = horizontal;
            if (Horizontal < 0)
                Horizontal = -1;
            if (Horizontal > 0)
                Horizontal = 1;
        }

        if (GetComponent<Movement>().vertical != 0)
        {
            Vertical = vertical;
            if (Vertical < 0)
                Vertical = -1;
            if (Vertical > 0)
                Vertical = 1;
        }

        direction = Vector3.zero;

        //float vinkel = Input.GetAxis("Horizontal");


        //if (Input.GetKey(KeyCode.A))
        //    direction = transform.right * -1;

        //if (Input.GetKey(KeyCode.D))
        //    direction = transform.right;

        //if (Input.GetKey(KeyCode.W))
        //    direction = transform.up;

        //if (Input.GetKey(KeyCode.S))
        //    direction = transform.up * -1;



        //if (Input.GetKey(KeyCode.D))
        //    transform.Rotate(0, 2, 0);
        ////GetComponent<Rigidbody>().AddForce(Vector3.right * 50);

        //if (Input.GetKey(KeyCode.A))
        //    transform.Rotate(0, -2, 0);
        BulletCd--;
        if (BulletCd < 0)
            BulletCd = 0;

        if (Input.GetKeyDown(KeyCode.F) && BulletCd == 0)
        {
            GameObject bullet = Instantiate(Projectile, shooter.position + (transform.forward * ScaleChange), transform.rotation);
            bullet.transform.localScale = new Vector3(ScaleChange, ScaleChange, ScaleChange);
            bullet.GetComponent<ProjectileScript>().Direction = new Vector2(Horizontal, Vertical);
            BulletCd = 5;
        }






        


        transform.position += direction * speed * Time.deltaTime;
    }
}
