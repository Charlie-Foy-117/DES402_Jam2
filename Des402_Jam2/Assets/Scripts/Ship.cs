using UnityEngine;

public class Ship : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int health;

    [Header("Refs")]
    [SerializeField] private Camera shipCam;
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        if (gameManager == null) { gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>(); }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Died();
        }
    }

    private void Died()
    {
        gameManager.EndGame();
    }
}
