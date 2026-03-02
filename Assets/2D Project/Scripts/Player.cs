using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;

    void Start()
    {
        // todo - get and cache animator
    }
    
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            Debug.Log("Bang!");
            GetComponent<Animator>().SetTrigger("hasShot");
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
}
