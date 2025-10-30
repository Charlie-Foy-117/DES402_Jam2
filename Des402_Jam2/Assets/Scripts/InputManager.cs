using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private ShipController shipController;
    private BeaconController beaconController;
    private GameManager gameManager;
    private int index = -1;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        playerInput = GetComponent<PlayerInput>();
        shipController = FindFirstObjectByType<ShipController>();
        beaconController = FindFirstObjectByType<BeaconController>();
        index = playerInput.playerIndex;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (gameManager.GetSceneIndex() == 2)
        {
            if (index == 0)
            {
                shipController.SetMoveInput(context.ReadValue<Vector2>());
            }
            else if (index == 1)
            {
                beaconController.SetMoveInput(context.ReadValue<Vector2>());
            }
            else { Debug.Log("Index outside of player count"); }
        }
    }

    public void OnTurn(InputAction.CallbackContext context)
    {
        if (gameManager.GetSceneIndex() == 2)
        {
            if (index == 0)
            {
                shipController.SetTurnInput(context.ReadValue<Vector2>());
            }
            else if (index == 1)
            {
                beaconController.SetTurnInput(context.ReadValue<Vector2>());
            }
            else { Debug.Log("Index outside of player count"); }
        }
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        if (gameManager.GetSceneIndex() == 0)
        {
            gameManager.StartGame();
        }
    }
}
