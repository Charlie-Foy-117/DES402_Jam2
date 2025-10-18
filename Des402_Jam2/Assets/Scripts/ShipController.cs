using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int moveSpeed;
    [SerializeField] private int maxForce;
    [SerializeField] private int turnSpeed;

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

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnTurn(InputAction.CallbackContext context)
    {
        turnInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        Move();
        transform.Rotate(Vector3.up * turnInput.x * turnSpeed);
    }

    private void Move()
    {
        currentVelocity = rb.linearVelocity;
        targetVelocity = new Vector3(moveInput.x, 0, moveInput.y);
        targetVelocity *= moveSpeed;

        targetVelocity = transform.TransformDirection(targetVelocity);

        velocityChange = (targetVelocity - currentVelocity);

        Vector3.ClampMagnitude(velocityChange, maxForce);

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }
}
