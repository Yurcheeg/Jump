using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public enum Scenes
    {
        MainMenu,
        Game
    };
    public void ChangeScene(int sceneId)
    {
        Scenes scene = (Scenes)sceneId;
        SceneManager.LoadScene(scene.ToString());
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}
