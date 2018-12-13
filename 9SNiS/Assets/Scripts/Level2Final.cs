﻿using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Level2Final : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D BoxCollider2D)
    {
        if (BoxCollider2D.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Final");
        }
    }
}
