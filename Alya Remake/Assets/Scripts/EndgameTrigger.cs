using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndgameTrigger : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
