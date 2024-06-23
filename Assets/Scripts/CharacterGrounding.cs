using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public class CharacterGrounding : MonoBehaviour
{
    public PlayerState currentState = PlayerState.Grounded;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Ground>())
        {
            currentState = PlayerState.Grounded;
        }
    }
}
