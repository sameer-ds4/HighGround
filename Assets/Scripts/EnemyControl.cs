using UnityEngine;
using DG.Tweening;
using System.Collections;

public class EnemyControl : MonoBehaviour
{
    public Vector3 currentPosition;
    public enemyDirection direction;
    [SerializeField]
    private Vector2 minMaxStep;
    private int jumpCount;
    private float x, y, z;

    public delegate void AttackPlayer();
    public static event AttackPlayer OnHit;

    private void OnEnable() 
    {
        PlayerInput.DropThunder += MoveStep;

        SpawnAnimate();
    }

    private void OnDisable() 
    {
        PlayerInput.DropThunder -= MoveStep;
    }


    void Start()
    {
        minMaxStep = new Vector2(-2f, 2f);
        y = 0.5f;
    }

    void Update()
    {
        if(!GameManager.gameStart) return;

        if(Input.GetKeyDown(KeyCode.Space))
            MoveStep();
    }

    private void SpawnAnimate()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 0.7f);
    }

    private void MoveStep()
    {
        switch(direction)
        {
            case enemyDirection.Left:
                x = 0.5f;
                z = VariableElement(currentPosition.z);
                break;

            case enemyDirection.Right:
                x = -0.5f;
                z = VariableElement(currentPosition.z);
                break;

            case enemyDirection.Up:
                z = -0.5f;
                x = VariableElement(currentPosition.x);
                break;

            case enemyDirection.Down:
                z = 0.5f;
                x = VariableElement(currentPosition.x);
                break;
        }

        Jump();
    }

    private void Jump()
    {
        minMaxStep += new Vector2(0.5f, -0.5f);

        jumpCount++;
        if(gameObject.transform != null)
        {
            transform.DOJump(currentPosition + new Vector3(x, y, z), 0.5f, 1, 0.5f).OnComplete
            (() => 
            {
                currentPosition = transform.position;
            });
        }
    }

    private float VariableElement(float currPt)
    {
        if(currPt == minMaxStep.x)
            return 0.5f;
        else if(currPt == minMaxStep.y)
            return -0.5f;
        
        int x = Random.Range(0,2);

        if(x == 0)
            return 0.5f;
        else
            return -0.5f;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            OnHit?.Invoke();
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDestroy() 
    {
        transform.DOKill();
    }
}