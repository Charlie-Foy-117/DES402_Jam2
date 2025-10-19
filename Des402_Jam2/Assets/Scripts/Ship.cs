using UnityEngine;

public class Ship : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int health;

    [Header("Refs")]
    [SerializeField] private Camera shipCam;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Ship has died");
        }
    }
}
