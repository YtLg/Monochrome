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

    void Start()
    {
        grounded = false;
    }

    // Update is called once per frame
    void Update()
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
            player.velocity= new Vector2(player.velocity.x, 4f * addedForce);
        }
    }



    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.CompareTag("Platform"))
        {
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D obj)
    {
        if (obj.gameObject.CompareTag("Platform"))
        {
            grounded = false;
        }
    }

}
