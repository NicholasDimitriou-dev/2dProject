using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDiedFunc(int points);

    public static event EnemyDiedFunc OnEnemyDied;

    public int pointTotal = 10;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
        if (collision.gameObject.layer == LayerMask.NameToLayer("bullet")) {
            Destroy(collision.gameObject);
            OnEnemyDied?.Invoke(pointTotal);
            Destroy(this.gameObject); 
        }
        
        // todo - destroy the bullet
        // todo - trigger death animation
    }
    private void OnDestroy()
    {
        Enemy.OnEnemyDied -= OnEnemyDied;
    }
}
