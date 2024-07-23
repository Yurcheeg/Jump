using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    private Pause optionsMenu;
    [SerializeField]private Button button;
    private static bool isFrozen;

    void Start()
    {
        
        if (button != null)
        {
            button.interactable = true;
        }
        optionsMenu = FindObjectOfType<Pause>(true);

    }

    private void Update()
    {
        if (Player.currentState == Player.PlayerState.Dying && button != null)
        {
            button.interactable = false;
        }
        else if (button != null)
        {
            button.interactable = true;
        }
    }

    void FreezeGameToggle()
    {
        isFrozen = !isFrozen;
        Time.timeScale = Convert.ToInt32(!isFrozen);
        Debug.Log($"timescale: {Time.timeScale}");
        
    }
    public void OpenPauseMenu()
    {
        if(!optionsMenu.gameObject.activeSelf)
        {
            optionsMenu.gameObject.SetActive(true);
            if (SceneManager.GetActiveScene().name == "Game")
            {
                FreezeGameToggle();
            }
            
        }
    }
    public void ClosePauseMenu()
    {
        optionsMenu.gameObject.SetActive(false);
        if (SceneManager.GetActiveScene().name == "Game")
        {
            FreezeGameToggle();
        }
    }
}
