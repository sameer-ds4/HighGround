using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyControl enemyPrefab;

    float x, y, z;
    
    void Start()
    {
        y = 0.5f;
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        enemyDirection direction = GetDirection();
        SetCoord(direction);
        EnemyControl _ene = Instantiate(enemyPrefab, new Vector3(x, y, z), Quaternion.identity);
        _ene.currentPosition = new Vector3(x, y, z);
    }

    private enemyDirection GetDirection()
    {
        int x = Random.Range(0, 4);
        return (enemyDirection)x;
    }

    private void SetCoord(enemyDirection direction)
    {
        float a = -2.5f;
        switch (direction)
        {
            case enemyDirection.Left:
                x = -2.7f;
                z = a + Random.Range(0, 4);
                break;

            case enemyDirection.Right:
                x = 1.7f;
                z = a + Random.Range(0, 4);
                break;

            case enemyDirection.Up:
                z = 1.7f;
                x = a + Random.Range(0, 4);
                break;

            case enemyDirection.Down:
                z = -2.7f;
                x = a + Random.Range(0, 4);
                break;
        }
    }
}


public enum enemyDirection
{
    Left,
    Right,
    Up,
    Down,
}