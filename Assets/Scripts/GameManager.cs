using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("UI Pages")]
    [SerializeField] private GameObject mainMenu;


    public static bool gameStart;

    void Start()
    {
        gameStart = false;
    }

    void Update()
    {
        
    }
}
