using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int forwardSpeed;
    [SerializeField] private int reverseSpeed;
    [SerializeField] private int maxForce;
    [SerializeField] private int turnSpeed;

    public int playerIndex = 0;

    private Rigidbody rb;
    private Vector3 moveInput;
    private Vector3 turnInput;
    private Vector3 velocityChange;
    private Vector3 targetVelocity;
    private Vector3 currentVelocity;



    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void OnMoveShip(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnTurnShip(InputAction.CallbackContext context)
    {
        turnInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        currentVelocity = rb.linearVelocity;
        targetVelocity = new Vector3(0, 0, moveInput.y);
        if (moveInput.y > 0)
        {
            targetVelocity *= forwardSpeed;
        }
        else if (moveInput.y < 0)
        {
            targetVelocity *= reverseSpeed;
        }
        else { Debug.Log("MoveInput is 0"); }

        targetVelocity = transform.TransformDirection(targetVelocity);

        velocityChange = (targetVelocity - currentVelocity);

        Vector3.ClampMagnitude(velocityChange, maxForce);

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    private void Turn()
    {
        transform.Rotate(Vector3.up * turnInput.x * turnSpeed);
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    public void SetMoveInput(Vector3 newMoveInput)
    {
        moveInput = newMoveInput;
    }

    public void SetTurnInput(Vector3 newTurnInput)
    {
        turnInput = newTurnInput;
    }
}
