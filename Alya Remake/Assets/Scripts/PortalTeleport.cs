﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public LevelLoader loadLevel;

    void OnTriggerEnter(Collider other)
    {
        loadLevel.LoadNextLevel();
    }
}
