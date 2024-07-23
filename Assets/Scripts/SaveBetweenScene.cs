using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveBetweenScene : MonoBehaviour
{
    private static HashSet<string> hasExecuted = new HashSet<string>();
    void Awake()
    {
        //ids are used to prevent multiplication of game objects when you return to the scene
        string uniqueId = gameObject.name;

        if(hasExecuted.Contains(uniqueId))
        {
            Destroy(gameObject);
            return;
        }
        hasExecuted.Add(uniqueId);

        DontDestroyOnLoad(gameObject);

    }
    
}
