using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyControl enemyPrefab;

    float x, y, z;

    private void OnEnable() 
    {
        PlayerInput.DropThunder += DropEnemies;
    }

    private void OnDisable() 
    {
        PlayerInput.DropThunder -= DropEnemies;
    }
    
    void Start()
    {
        y = 0.5f;
        SpawnEnemy();
    }

    private void DropEnemies()
    {
        int x = Random.Range(1, 3);

        for (int i = 0; i < x; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        enemyDirection direction = GetDirection();
        SetCoord(direction);
        EnemyControl _ene = Instantiate(enemyPrefab, new Vector3(x, y, z), Quaternion.identity);
        _ene.currentPosition = new Vector3(x, y, z);
        _ene.direction = direction;
    }

    private enemyDirection GetDirection()
    {
        int x = Random.Range(0, 4);
        return (enemyDirection)x;
    }

    private void SetCoord(enemyDirection direction)
    {
        float a = -2f;
        switch (direction)
        {
            case enemyDirection.Left:
                x = -2.2f;
                z = a + Random.Range(0, 4);
                break;

            case enemyDirection.Right:
                x = 2.2f;
                z = a + Random.Range(0, 4);
                break;

            case enemyDirection.Up:
                z = 2.2f;
                x = a + Random.Range(0, 4);
                break;

            case enemyDirection.Down:
                z = -2.2f;
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