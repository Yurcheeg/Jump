using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

using static Player;

public class PlayerMovement : MonoBehaviour
{
   private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 8f;
    public PlayerState currentState = PlayerState.Grounded;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CameraFollow cam;
    [SerializeField] Image image;
    [SerializeField] private float collisionThreshhold;

    [SerializeField] private CoinPickup coinPickup;
    // Update is called once per frame
    private void Awake()
    {
        image.gameObject.SetActive(false);
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump") && currentState == PlayerState.Grounded)
        {
            currentState = PlayerState.Jumping;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        /*if(rb.velocity.y == 0) // CHANGE TO GROUND DETECTION
        {
            currentState = PlayerState.Grounded;
        }*/
        if (rb.position.y < cam.transform.position.y-6)
        {
            Death();
        }
        

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ground>())
        {
            if (rb.position.y > collision.transform.position.y + 1) // i have no idea why 1 but it works
            {
                Debug.Log($"Collision pos: {collision.transform.position.y}");
                currentState = PlayerState.Grounded;
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.GetComponent<Coin>())
        {
            coinPickup.CoinPick(other);
        }
    }

    void Death()
    {
        currentState = PlayerState.Dying;
        image.gameObject.SetActive(true);
        rb.gameObject.SetActive(false);
    }
}
