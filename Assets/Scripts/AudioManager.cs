using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioManager audioManager;
    public AudioSource music;
    public List<AudioSource> sfx = new();
    public static bool musicMute;
    public static bool sfxMute;
    [SerializeField] GameObject musicToggle;
    [SerializeField] GameObject sfxToggle;
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        musicMute = Convert.ToBoolean(PlayerPrefs.GetInt("musicMute",0));

        if (musicMute)
        {
            musicToggle.SetActive(false);
        }
        else musicToggle.SetActive(true);

        sfxMute = Convert.ToBoolean(PlayerPrefs.GetInt("sfxMute",0));

        if (sfxMute)
        {
            sfxToggle.SetActive(false);
        }
        else sfxToggle.SetActive(true);

        if (musicMute == false)
        {
            music.mute = false;
        }
        SceneManager.sceneLoaded += OnSceneLoad;
        //get values using playerprefs
    }

    public void ToggleAudio()
    {
        musicMute = !musicMute;
        musicToggle.SetActive(!musicMute);
        music.mute = musicMute;
        PlayerPrefs.SetInt("musicMute",Convert.ToInt32(musicMute));
    }
    public void ToggleSfx()
    {
        sfxMute = !sfxMute;
        sfxToggle.SetActive(!sfxMute);
        PlayerPrefs.SetInt("sfxMute", Convert.ToInt32(sfxMute));
    }
    void OnSceneLoad(Scene scene,LoadSceneMode loadSceneMode)
    {
        foreach (AudioSource sfx in Resources.FindObjectsOfTypeAll<AudioSource>())
        {
            if(sfx.GetComponent<SFX>())
            {
                this.sfx.Add(sfx);
                if (sfxMute)
                {
                        sfx.mute = true;
                }
            }
        }
        
    }
}
