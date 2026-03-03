using System;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    private int n = 0;
    int i = 0;
    float direction = -0.25f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wall.wallCollide += wallCollide;
    }

    // Update is called once per frame
    void Update()
    {
        
        int k = 50 - n;
        if (k == i)
        {
            transform.position += new Vector3(direction, 0, 0);
            i = 0;
        }

        i++;
        // Debug.Log(transform.childCount);
        if (transform.childCount > 16) {
            n = 0;
        }else if(transform.childCount > 11) {
            n = 10;
        }else if (transform.childCount > 6) {
            n = 20;
        }else if (transform.childCount > 1) {
            n = 30;
        }else {
            n = 40;
        }

    }
    
    void wallCollide()
    {
        Debug.Log("enter");
        // float newDirection = direction * -1;
        // direction = newDirection;
        if (transform.position.x < 0)
        {
            direction = 0.25f;
            transform.position = new Vector3(transform.position.x+.25f,transform.position.y-0.1f, 0);
        }else {
            direction = -0.25f;
            transform.position = new Vector3(transform.position.x-.25f,transform.position.y-0.1f, 0);    
        }
        
    }
}
