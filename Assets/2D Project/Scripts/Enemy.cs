using System;
using System.Collections;
using Mono.Cecil;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDiedFunc(int points, AudioClip death);

    public AudioClip death;
    public AudioClip fire;
    AudioSource audio;

    public GameObject bullet;
    public GameObject thing;
    public Transform shootOffsetTransform;
    public Transform shootOffsetTransform2;
    private Transform parent;
    public static event EnemyDiedFunc OnEnemyDied;

    public int pointTotal = 10;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        parent = GetComponent<Transform>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.layer == LayerMask.NameToLayer("bullet") && collision.gameObject.tag == "Player") {
            Destroy(collision.gameObject);
            GetComponent<Animator>().SetTrigger("hasDied");
            // audio.PlayOneShot(death);
            // AudioSource.PlayClipAtPoint(death,transform.position);
            OnEnemyDied?.Invoke(pointTotal, death);
            StartCoroutine(Cooldown(1f));
            
        }
        
        // todo - destroy the bullet
        // todo - trigger death animation
    }
    IEnumerator Cooldown(float seconds)
    {
        Debug.Log("entered");
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject); 
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
        GameObject explo = Instantiate(thing, transform.position + shootOffsetTransform2.position, Quaternion.Euler(180,180,180));
        explo.transform.SetParent(parent);
        audio.PlayOneShot(fire);
        Destroy(explo, 1f);
        Destroy(shot, 3f);
    }
}
