using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour {

    public Transform[] patrolPoints;
    public GameObject Bullet;
    public float speed;
    Transform currentPatrolPoint;
    int currentPatrolIndex;

    int timer;
    public Transform target;
    public float chaseRange;
    

    // Use this for initialization
    void Start () {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
	}
	
	// Update is called once per frame
	void Update () {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if(distanceToTarget < chaseRange)
        {
            //Start casing the target - turn and move towards target
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);

            // transform.Translate (Vector3.up * Time.deltaTime * speed);

            timer++;
            if(timer >= 180)
            {
                Instantiate(Bullet, transform.position, Quaternion.identity);
                timer = 0;
            }
            
            
        }

        
        
	}
}
