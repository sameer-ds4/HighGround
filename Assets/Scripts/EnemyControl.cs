using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public Vector3 currentPosition;


    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            MoveStep();
    }

    private void MoveStep()
    {
        Debug.LogError("Moving one step");
    }
}
