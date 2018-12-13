using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void ToGame()
    {
        SceneManager.LoadScene("Story");
    }
}
