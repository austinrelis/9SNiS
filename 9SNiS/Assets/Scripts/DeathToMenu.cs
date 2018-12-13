using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class DeathToMenu : MonoBehaviour
{
    public void ToGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
