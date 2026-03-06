using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;
    public GameManager scipt;
    public delegate void PlayerDiedFunc(AudioClip death);

    public AudioClip death;
    public AudioClip fire;
    AudioSource audio;
    public static event PlayerDiedFunc OnPlayerDied;

    void Start()
    {
        // todo - get and cache animator
    }
    
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            GetComponent<Animator>().SetTrigger("hasShot");
            audio.PlayOneShot(fire);
            Destroy(shot, 3f);
            // todo - destroy the bullet after 3 seconds
            // todo - trigger shoot animation
        }

        if (Keyboard.current != null && Keyboard.current.aKey.isPressed)
        {
            transform.position += new Vector3(-5f * Time.deltaTime, 0, 0);
        }
        if (Keyboard.current != null && Keyboard.current.dKey.isPressed)
        {
            transform.position += new Vector3(5f * Time.deltaTime, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("hit");
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
            // audio.PlayOneShot(death);
            // AudioSource.PlayClipAtPoint(death,transform.position);
            StartCoroutine(Cooldown(1.5f));
            
        }

    }
    IEnumerator Cooldown(float seconds)
    {
        Debug.Log("entered");
        GetComponent<Animator>().SetTrigger("hasDied");
        yield return new WaitForSeconds(seconds);
        OnPlayerDied?.Invoke(death);
        Destroy(this.gameObject); 
        scipt.credits();
    }
}
