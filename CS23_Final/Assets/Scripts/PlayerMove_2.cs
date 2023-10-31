using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMove_2 : MonoBehaviour
{
    //public Transform[] scenes;
    //private int rangeEnd;
    //public Animator anim;
    //public AudioSource WalkSFX;
    public Rigidbody2D rb2D;
    private bool FaceRight = true; // determine which way player is facing.
    public static float runSpeed = 10f;
    public float startSpeed = 10f;
    public bool isAlive = true;
    public GameObject past;
    public GameObject present;
    public GameObject future;

    public GameObject past_player;
    public GameObject present_player;
    public GameObject future_player;

    void Start()
    {
        //anim = gameObject.GetComponentInChildren<Animator>();
        rb2D = transform.GetComponent<Rigidbody2D>();
        //rangeEnd = scenes.Length - 1;

    }

    void Update()
    {
        //NOTE: Horizontal axis: [a] / left arrow is -1, [d] / right arrow is 1
        //NOTE: Vertical axis: [w] / up arrow, [s] / down arrow
        Vector3 hvMove = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        if (isAlive == true)
        {
            transform.position = transform.position + hvMove * runSpeed * Time.deltaTime;

            if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
            {
                //     anim.SetBool ("Walk", true);
                //     if (!WalkSFX.isPlaying){
                //           WalkSFX.Play();
                //     }
            }
            else
            {
                //     anim.SetBool ("Walk", false);
                //     WalkSFX.Stop();
            }

            // Turning. Reverse if input is moving the Player right and Player faces left.
            if ((hvMove.x < 0 && !FaceRight) || (hvMove.x > 0 && FaceRight))
            {
                playerTurn();
            }
        }
        // FOR CHANGING SCENES
        if (Input.GetKeyDown("1"))
        {
            past.SetActive(true);
            present.SetActive(false);
            future.SetActive(false);

            past_player.SetActive(true);
            present_player.SetActive(false);
            future_player.SetActive(false);
        }
        if (Input.GetKeyDown("2"))
        {
            past.SetActive(false);
            present.SetActive(true);
            future.SetActive(false);

            past_player.SetActive(false);
            present_player.SetActive(true);
            future_player.SetActive(false);
        }
        if (Input.GetKeyDown("3"))
        {
            past.SetActive(false);
            present.SetActive(false);
            future.SetActive(true);

            past_player.SetActive(false);
            present_player.SetActive(false);
            future_player.SetActive(true);
        }
    }



    private void playerTurn()
    {
        // NOTE: Switch player facing label
        FaceRight = !FaceRight;

        // NOTE: Multiply player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "wall")
    //    {
            
    //    }
    //}
}