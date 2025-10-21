using System;
using UnityEngine;

public class BeaconController : MonoBehaviour
{
    [Header("Settings")]
    public int playerIndex = 1;
    [SerializeField] private int turnSpeed;
    [SerializeField] private int verticalSpeed;
    [SerializeField] private float maxVerAngle;
    [SerializeField] private float minVerAngle;
    [SerializeField] private float maxHorAngle;
    [SerializeField] private float minHorAngle;

    [Header("Refs")]
    [SerializeField] private Light beacon;
    [SerializeField] private GameObject swivel;

    private Vector3 moveInput;
    private Vector3 turnInput;

    private void Start()
    {
        
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
        Debug.Log(beacon.transform.eulerAngles.x);
        Debug.Log(swivel.transform.eulerAngles.y);
        Move();
        Turn();
    }

    private void Move()
    {
        float pitchInput = -moveInput.y * verticalSpeed;
        float currentPitch = beacon.transform.localEulerAngles.x;
        if (currentPitch > 180f) currentPitch -= 360f;

        float newPitch = Mathf.Clamp(currentPitch + pitchInput, minVerAngle, maxVerAngle);

        Vector3 newRotation = beacon.transform.localEulerAngles;
        newRotation.x = newPitch < 0 ? newPitch + 360f : newPitch;
        beacon.transform.localEulerAngles = newRotation;

        //beacon.transform.Rotate(Vector3.left * moveInput.y * verticalSpeed);
        //beacon.transform.RotateAround(beacon.transform.position, Vector3.left, moveInput.y * verticalSpeed);
    }

    private void Turn()
    {
        float yawInput = turnInput.x * turnSpeed;
        float currentYaw = swivel.transform.localEulerAngles.y;
        if (currentYaw > 180f) currentYaw -= 360f;

        float newYaw = Mathf.Clamp(currentYaw + yawInput, minHorAngle, maxHorAngle);

        Vector3 newRotation = swivel.transform.localEulerAngles;
        newRotation.y = newYaw < 0 ? newYaw + 360f : newYaw;
        swivel.transform.localEulerAngles = newRotation;

        //swivel.transform.Rotate(Vector3.up * turnInput.x * turnSpeed);
        //swivel.transform.RotateAround(swivel.transform.position, Vector3.up, turnInput.x * turnSpeed);
    }
}
