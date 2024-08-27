using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public TextMeshProUGUI scoreFinalText;
    public TextMeshProUGUI killsFinalText;

    private void OnEnable() 
    {
        GetInfo();
    }

    private void GetInfo()
    {
        killsFinalText.text = GameStats.kills.ToString();
        scoreFinalText.text = (GameStats.kills * 50).ToString();
    }
}
