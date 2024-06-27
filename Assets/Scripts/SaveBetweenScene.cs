using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveBetweenScene : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
