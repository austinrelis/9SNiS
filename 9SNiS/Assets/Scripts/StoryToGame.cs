using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class StoryToGame : MonoBehaviour
{
    public void ToGame()
    {
        SceneManager.LoadScene("Level1");
    }
}

