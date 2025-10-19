using UnityEngine;

public class Hazard : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int damage;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ship"))
        {
            other.gameObject.GetComponent<Ship>().TakeDamage(damage);
        }
    }
}
