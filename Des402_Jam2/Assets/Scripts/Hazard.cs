using UnityEngine;

public class Hazard : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int damage;
    private Score scoreManager;

    private void Start()
    {
        scoreManager = FindFirstObjectByType<Score>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ship"))
        {
            other.gameObject.GetComponent<Ship>().TakeDamage(damage);
            scoreManager.ShipCollide();
        }
    }
}
