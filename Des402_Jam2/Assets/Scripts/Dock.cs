using UnityEngine;

public class Dock : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ship"))
        {
            gameManager.EndGame(true);
        }
    }
}
