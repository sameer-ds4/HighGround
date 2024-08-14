using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameStats : MonoBehaviour
{
    public static int lives = 5;
    public static int kills = 0;

    [SerializeField] private TextMeshProUGUI killsDisp;
    [SerializeField] private Image healthBar;
    [SerializeField]private Gradient colorGrad;

    private void OnEnable() 
    {
        PlayerInput.DropThunder += IncrementKill;
        EnemyControl.OnHit += TakeDamage;
    }

    private void OnDisable() 
    {
        PlayerInput.DropThunder -= IncrementKill;
        EnemyControl.OnHit -= TakeDamage;
    }

    void Start()
    {
        UpdateKill();
        UpdateLife();
    }

    private void IncrementKill()
    {
        kills++;
        UpdateKill();
    }

    private void UpdateKill()
    {
        killsDisp.text = "KILLS: " + kills;
    }

    private void TakeDamage()
    {
        lives--;
        UpdateLife();
    }

    private void UpdateLife()
    {
        float availableLife = (float)lives/5;
        healthBar.DOFillAmount(availableLife, 0.6f);
        healthBar.color = colorGrad.Evaluate(availableLife);

        CheckEnd();
    }

    private void CheckEnd()
    {
        if(lives == 0)
            GameManager.Instance.EndPlay();
    }
}
