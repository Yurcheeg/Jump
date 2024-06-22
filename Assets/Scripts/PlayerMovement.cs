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
        if(rb.velocity.y == 0) // CHANGE TO GROUND DETECTION
        {
            currentState = PlayerState.Grounded;
        }

        if(rb.position.y < cam.transform.position.y-6)
        {
            Death();
        }
        

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    
    void Death()
    {
        currentState = PlayerState.Dying;
        image.gameObject.SetActive(true);
    }
}
