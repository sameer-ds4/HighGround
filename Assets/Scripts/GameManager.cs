using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    [Header("UI Pages")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject inGameSc;
    [SerializeField] private GameObject gameEndSc;


    public static bool gameStart;

    private void Awake() 
    {
        Instance = this;
    }

    void Start()
    {
        mainMenu.SetActive(true);
        gameStart = false;
    }


    public void StartPlay()
    {
        mainMenu.SetActive(false);
        inGameSc.SetActive(true);

        gameStart = true;
    }

    public void EndPlay()
    {
        gameStart = false;

        inGameSc.SetActive(false);
        gameEndSc.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
