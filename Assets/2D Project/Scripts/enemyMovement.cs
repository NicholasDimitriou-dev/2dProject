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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -3.5f)
        {
            direction = 0.25f;
            transform.position = new Vector3(transform.position.x+.5f,transform.position.y-0.25f, 0);
        }
        
        if (transform.position.x >= 6.5f)
        {
            direction = -0.25f;
            transform.position = new Vector3(transform.position.x-.5f,transform.position.y-0.25f, 0);
        }
        
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
           
            
        }
    }
    void wallCollide()
    {
        Debug.Log("enter");
        float newDirection = direction * -1;
        direction = newDirection;
        transform.position = new Vector3(0f, -1f, 0f);
    }
}
