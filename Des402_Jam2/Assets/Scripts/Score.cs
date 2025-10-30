using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private float gameTime;
    [SerializeField] private float maxGameTime;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private UIManager uiManager;

    [Header("Score Values")]
    [SerializeField] private int timeLossScore = 1; //score per second to lose during gametime
    [SerializeField] private int collisionLossScore = 5; //score lost on collision
    private void Awake()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        uiManager = FindFirstObjectByType<UIManager>();
        maxGameTime = gameManager.GetMaxGameTime();
        StartCoroutine(DeprecateScore());
    }
    private void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        uiManager.UpdateScoreText(score);
    }

    public void ShipCollide()
    {
        AddToScore(-collisionLossScore);
    }

    private void Update()
    {
        if (gameTime < maxGameTime)
        {
            gameTime += Time.deltaTime;
        }
        else { gameManager.EndGame(false); }
    }

    IEnumerator DeprecateScore()
    {
        AddToScore(-timeLossScore);
        yield return new WaitForSeconds(1.0f);
        if (!gameManager.GetGamePaused()) { StartCoroutine(DeprecateScore()); }
    }
}
