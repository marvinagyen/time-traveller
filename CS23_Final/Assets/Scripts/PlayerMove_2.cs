using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMove_2 : MonoBehaviour
{
    //public Transform[] scenes;
    //private int rangeEnd;
    //public Animator anim;
    //public AudioSource WalkSFX;


    private Rigidbody2D rb2D;
    private bool FaceRight = true; // determine which way player is facing.
    public static float runSpeed = 10f;
    public float startSpeed = 10f;
    public bool isAlive = true;
    //CHANGE BEFORE DONE THIS IS JUST TO MAKE BUILDING EASIER
    public bool canTimeTravel = true;

    public bool hasSeed = false;
    public bool beenPlanted = false;
    public bool beenPicked = false;
   
    public Vector3 respawnPoint;

    public bool hasWatchKey = false;

    public GameObject watchWalls;

    public AudioSource doorjiggle;

    private bool Past;
    private bool Present;
    private bool Future;

    public int deathCount = 0;

    void Start()
    { 
        rb2D = transform.GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        

    }

    void FixedUpdate()
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
        hasWatchKey = GameObject.FindWithTag("GameHandler").GetComponent<GameInventory>().hasWatchKey;

        Present = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>().isPresent;
        Future = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>().isFuture;
        Past = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>().isPast;

        if (Input.GetKeyDown(KeyCode.P))
        {
         
            if (hasSeed && Present){
                string message = "Exciting! I wonder how long it might take to grow";
                GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>().makeMessagesAppear(message);
                GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>().future_pot_w_flower.SetActive(true);
                GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>().future_pot.SetActive(false);
                beenPlanted = true;
                GameObject.FindWithTag("GameHandler").GetComponent<GameInventory>().InventoryRemove("item5", 1);

            }

            if(beenPlanted && Future && !beenPicked)
            {
                Debug.Log("in");
                string message = "I bet I could make something really dangerous with this poison flower!";
                GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>().makeMessagesAppear(message);
                GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>().future_pot_w_flower.SetActive(false);
                GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>().picked_flower.SetActive(true);
                beenPicked = true;
                GameObject.FindWithTag("GameHandler").GetComponent<GameInventory>().InventoryAdd("item6");

            }
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "watch"){
            canTimeTravel = true;
            string message = "Woahhh... what's happening to me?? It feels like if you pressed 1, 2, or 3,\nsomething crazy might happen";
            GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>().makeMessagesAppear(message);
            GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>().progressBar1.SetActive(true);
            Destroy(other.gameObject);
           
        }

        if (other.gameObject.tag == "time2")
        {
            GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>().progressBar2.SetActive(true);
            string message = "You found another piece of the time machine!";
            GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>().makeMessagesAppear(message);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "watchWall")
        {
            Debug.Log("test wall hit");

            if (hasWatchKey)
            {
                watchWalls.SetActive(false);
                GameObject.FindWithTag("GameHandler").GetComponent<GameInventory>().InventoryRemove("item3", 1);

            }
            else
            {
                GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>().msgtxt.text = "It looks like this door is locked...\nWait! A keyhole!\nMaybe I could fashion a key...";
                GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>().textButton.SetActive(true);
                doorjiggle.Play(0);
            }

        }

        if (other.gameObject.tag == "pot_past")
        {
            string message = "What good is a pot if there is no soil in it?";
            GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>().makeMessagesAppear(message);
        }

        if (other.gameObject.tag == "pot_present")
        {
            string message;
            if (hasSeed && !beenPlanted)
            {
                message = "Press P to plant!";
                GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>().makeMessagesAppear(message);

            }
            else if (!hasSeed)
            {
                message = "Seems like this would be a great place to plant something...\nA seed perhaps?";
                GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>().makeMessagesAppear(message);

            }
        }

        if (other.gameObject.tag == "pot_future")
        {
            string message = "";
            if (beenPlanted)
            {
                message = "Did the soil make the flower poisonous? Press P to pick it!";
                if (beenPicked)
                {
                    message = "Seems like this plant has been\npicked already";
                }
            }
            else
            {
                message = "This soil seems way too toxic\nto plant in!";
            }
            GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>().makeMessagesAppear(message);
        }






    }

       void OnTriggerEnter2D (Collider2D collision) {
        if (collision.tag == "enemy") {
            transform.position = respawnPoint;
            deathCount++;

            if (deathCount == 1)
            {
                string message = "Eek! These scientists are dangerous!\nI better not get too close.";
                GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>().makeMessagesAppear(message);
            }
        }
        else if (collision.tag == "Checkpoint") {

            respawnPoint = transform.position;
            }
    }
}

