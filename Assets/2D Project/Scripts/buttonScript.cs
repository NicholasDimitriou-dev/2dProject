using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Update()
    {
        if (Time.deltaTime >= 3f)
        {
            loadGame();
        }
    }
    
    public void loadGame()
    {
        SceneManager.LoadScene("2D Project/Scenes/Schmup");
    }

    public void loadCredit()
    {
        SceneManager.LoadScene("2D Project/Scenes/credits");
    }
}
