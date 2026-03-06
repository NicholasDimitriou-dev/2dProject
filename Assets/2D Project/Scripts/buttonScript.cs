using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    public AudioSource audio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(audio);
    }

    

    public void loadMenu()
    {
        SceneManager.LoadScene("2D Project/Scenes/mainMenu");
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
