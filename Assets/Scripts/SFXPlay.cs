using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public class SFXPlay : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AudioSource slimeJumpSfx;
    [SerializeField] private AudioSource coinPickupSfx;
    [SerializeField]CoinSpawn coinSpawn;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        slimeJumpSfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ground>() && rb.position.y > collision.transform.position.y + 1)
        {
            if (!AudioManager.sfxMute) // i have no idea why 1 but it works
            {
                
                slimeJumpSfx.Play();
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.GetComponent<Coin>())
        {
            if(!AudioManager.sfxMute)
            {
                coinPickupSfx.Play();
            }
            
        }
    }
}
