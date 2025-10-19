using UnityEngine;

public class BeaconController : MonoBehaviour
{
    [Header("Settings")]
    public int playerIndex = 1;
    private Vector3 moveInput;
    private Vector3 turnInput;

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
        Debug.Log(moveInput);
        Debug.Log(turnInput);
    }
}
