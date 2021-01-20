using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneLoadMainMenu : MonoBehaviour
{
    public GameObject player;

    public void TimelineLoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void DisablePlayer()
    {
        player.SetActive(false);
    }

}
