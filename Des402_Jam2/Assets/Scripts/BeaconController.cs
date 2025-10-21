using UnityEngine;

public class BeaconController : MonoBehaviour
{
    [Header("Settings")]
    public int playerIndex = 1;
    [SerializeField] private int turnSpeed;
    [SerializeField] private int verticalSpeed;

    [Header("Refs")]
    [SerializeField] private Light beacon;
    private Quaternion beaconTransform;


    private Vector3 moveInput;
    private Vector3 turnInput;

    private void Start()
    {
        beaconTransform = beacon.transform.rotation;
    }
    public void SetMoveInput(Vector3 newMoveInput)
    {
        moveInput = newMoveInput;
    }

    public void SetTurnInput(Vector3 newTurnInput)
    {
        turnInput = newTurnInput;
    }

    private void Update()
    {
        Debug.Log(beaconTransform);
        Move();
        Turn();
    }

    private void Move()
    {
        if (beaconTransform.x <= 90 && beaconTransform.x >= 0)
        {
            beacon.transform.Rotate(Vector3.left * moveInput.y * verticalSpeed);
        }
    }

    private void Turn()
    {
        beacon.transform.Rotate(Vector3.up * turnInput.x * turnSpeed);
    }
}
