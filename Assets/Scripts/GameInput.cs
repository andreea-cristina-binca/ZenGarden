using UnityEngine;


public class GameInput : MonoBehaviour
{

    public static GameInput Instance { get; private set; }


    private PlayerControls playerControls;


    private void Awake()
    {   
        if (Instance == null)
            Instance = this;

        playerControls = new PlayerControls();
        playerControls.Player.Enable();
    }

    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = playerControls.Player.Move.ReadValue<Vector2>();

        Debug.Log(inputVector);

        return inputVector;
    }

}
