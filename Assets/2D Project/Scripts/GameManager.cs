using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
       // todo - sign up for notification about enemy death 
       Enemy.OnEnemyDied += OnEnemyDied;
    }

    void OnEnemyDied(int points)
    {
        Debug.Log(points);
    }
}
