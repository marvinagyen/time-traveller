using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Vector3 respawnPoint;
    

    // Update is called once per frame
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement  * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D (Collider2D collision) {
        if (collision.tag == "enemy" ) {
            transform.position = respawnPoint;
        }
        else if (collision.tag == "Checkpoint") {

            respawnPoint = transform.position;
            }
    }
}
