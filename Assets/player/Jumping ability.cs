using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f; // the force applied to the player when they jump
    public bool isGrounded = false; // a boolean to check if the player is on the ground
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // if the spacebar is pressed and the player is on the ground
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // apply the jump force to the player
            isGrounded = false;
             // set grounded to false
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // if the player collides with the ground
        {
            isGrounded = true; // set grounded to true
        }
    }
}