using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D player;
    public SpriteRenderer playerRend;
    public float addedForce;
    public bool grounded;

    public GameObject spawn;

    int life; // 1 for alive, 0 for dead.

    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawn");
        grounded = false;
        life = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (life == 1)
        {
            // A + D + Space Movement
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                player.velocity = new Vector2(1.5f * addedForce, player.velocity.y);

                // sets flipping the player to be false
                playerRend.flipX = false;
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                player.velocity = new Vector2(-1.5f * addedForce, player.velocity.y);
                // sets flipping to true ( rotates them so they look at the side they walk to
                playerRend.flipX = true;
            }
            if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
            {
                player.velocity = new Vector2(player.velocity.x, 4f * addedForce);
            }
        }

        else
        {
            // do death animation thing
            player.transform.position = spawn.transform.position;
            life = 1;
            // possible death counter here.
        }
    }

    // used to relay and recieve gamestate.
    public int GetLife()
    {
        return life;
    }

    public void SetLife(int status)
    {
        life = status;
    }



    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.CompareTag("Platform"))
        {
            grounded = true;
        }

        if (obj.gameObject.CompareTag("Enemy"))
        {
            life = 0;
        }
    }

    void OnCollisionExit2D(Collision2D obj)
    {
        if (obj.gameObject.CompareTag("Platform"))
        {
            grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            life = 0;
        }
    }

}
