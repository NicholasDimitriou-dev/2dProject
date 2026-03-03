using System;
using UnityEngine;

public class wall : MonoBehaviour
{
    public delegate void wallFunc();
    
    public static event wallFunc wallCollide;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter2D(Collision2D other)
    {
       
        if (other.gameObject.CompareTag("enemy")) 
        {
            Debug.Log("enter");
            wallCollide?.Invoke();
        }
    }
}
