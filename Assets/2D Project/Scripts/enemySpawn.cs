using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.InputSystem;

public class enemySpawn : MonoBehaviour
{
    public TextAsset levelFile;
    public Transform levelRoot;

    [Header("Prefabs")]
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            LoadEnemy();
        }

        if (Keyboard.current != null && Keyboard.current.lKey.isPressed)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);   
            }

         LoadEnemy();
        }
    }
     void LoadEnemy()
        {
            // Push lines onto a stack so we can pop bottom-up rows. This is easy to reason
            //  about, but an index-based loop over the string array is faster.
            Stack<string> levelRows = new Stack<string>();
    
            foreach (string line in levelFile.text.Split('\n'))
                levelRows.Push(line);
    
            int row = 0;
            while (levelRows.Count > 0)
            {
                string rowString = levelRows.Pop();
                char[] rowChars = rowString.ToCharArray();
                
                for (var columnIndex = 0; columnIndex < rowChars.Length; columnIndex++)
                {
                    var currentChar = rowChars[columnIndex];
    
                    // Todo - Instantiate a new GameObject that matches the type specified by the character
                    // Todo - Position the new GameObject at the appropriate location by using row and column
                    // Todo - Parent the new GameObject under levelRoot
                    if (currentChar == '1')
                    {
                     Vector3 position = new Vector3(columnIndex-6.5f, row+0.5f, 0f);
                     Transform rockInstance = Instantiate(enemy1, levelRoot).transform;
                     rockInstance.position = position;   
                    }
                    if (currentChar == '2')
                    {
                        Vector3 position = new Vector3(columnIndex-6.5f, row+0.5f, 0f);
                        Transform rockInstance = Instantiate(enemy2, levelRoot).transform;
                        rockInstance.position = position;   
                    }
                    if (currentChar == '3')
                    {
                        Vector3 position = new Vector3(columnIndex-6.5f, row+0.5f, 0f);
                        Transform rockInstance = Instantiate(enemy3, levelRoot).transform;
                        rockInstance.position = position;   
                    }
                    if (currentChar == '4')
                    {
                        Vector3 position = new Vector3(columnIndex-6.5f, row+0.5f, 0f);
                        Transform rockInstance = Instantiate(enemy4, levelRoot).transform;
                        rockInstance.position = position;   
                    }
                    
                }
    
                row++;
            }
        }

}
