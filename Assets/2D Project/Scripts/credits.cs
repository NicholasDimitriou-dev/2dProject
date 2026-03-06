using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Cooldown(5));
        
    }

    IEnumerator Cooldown(int seconds)
    {
        Debug.Log("entered");
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("2D Project/Scenes/mainMenu");
    }
}
