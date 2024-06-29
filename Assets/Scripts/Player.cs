using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerState
    {
        Grounded,
        Jumping,
        Dying
    };
    public static PlayerState currentState = PlayerState.Grounded;

}
