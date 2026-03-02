using System;
using UnityEngine;

public class wall : MonoBehaviour
{
    public delegate void wallFunc();
    
    public static event wallFunc wallCollide;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("enter");
        if (other.gameObject.CompareTag("Finish")) 
        {
            wallCollide?.Invoke();
        }
    }
    
}
