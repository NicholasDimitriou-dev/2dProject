using System;
using UnityEngine;

public class health : MonoBehaviour
{
    private int life = 4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("bullet") || other.gameObject.layer == LayerMask.NameToLayer("enemyBullet"))
        {
            Destroy(other.gameObject);
            life--;
            if (life == 0)
            {
                Destroy(gameObject);
            }

            if (life == 1)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
            }

            if (life == 2)
            {
                GetComponent<SpriteRenderer>().color = Color.blue;
            }

            if (life == 3)
            {
                GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }
}
