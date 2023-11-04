using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathingScript : MonoBehaviour
{

    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D enemyRigid;
    public SpriteRenderer enemyRend;
    private Transform pointTowards;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigid = GetComponent<Rigidbody2D>();
        enemyRend = GetComponent<SpriteRenderer>();
        pointTowards = PointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // gives the direction the enemy will head in by getting the difference between goal and enemy.
        Vector2 point = pointTowards.position - transform.position;

        // if the point the enemy is going towards is point B, then it will:
        if (pointTowards == PointB.transform)
        {
            Debug.Log(transform.position + "And" + pointTowards.position);

            // add velocity to x direction as enemy goes left & right, left is negative, right is positive
            enemyRigid.velocity = new Vector2(speed, 0);
            enemyRend.flipX = true;
        }

        else
        {   // walk towards point A.
            enemyRigid.velocity = new Vector2(-speed, 0);
            enemyRend.flipX = false;
        }

        // if enemy's current directional goal is point B and its distance from it is under 0.5, then...
        if (Vector2.Distance(transform.position, pointTowards.position) < 0.5f && pointTowards == PointB.transform)
        {
            Debug.Log("B reached, swapping.");
            // Then it's new goal is point A.
            pointTowards = PointA.transform;
        }

        // same but for point A instead
        if (Vector2.Distance(transform.position, pointTowards.position) < 0.5f && pointTowards == PointA.transform)
        {
            // swap directional goal to point B
            pointTowards = PointB.transform;
        }
    }
}
