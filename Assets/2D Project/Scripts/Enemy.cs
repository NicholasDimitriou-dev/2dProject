using System;
using Mono.Cecil;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDiedFunc(int points);

    public GameObject bullet;
    public Transform shootOffsetTransform;
    public static event EnemyDiedFunc OnEnemyDied;

    public int pointTotal = 10;
    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.layer == LayerMask.NameToLayer("bullet") && collision.gameObject.tag == "Player") {
            Destroy(collision.gameObject);
            OnEnemyDied?.Invoke(pointTotal);
            Destroy(this.gameObject); 
        }
        
        // todo - destroy the bullet
        // todo - trigger death animation
    }

    private void Update()
    {
        float roll = Random.Range(0f, 1f);
        //Debug.Log(roll);
        if (roll > .9995)
        {
            Fire();
        }
    }
    private void Fire()
    {
        GameObject shot = Instantiate(bullet, transform.position + shootOffsetTransform.position, Quaternion.identity);
        Destroy(shot, 3f);
    }
}
