using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private PlayerControls playerControls;
    void Awake()
    {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;
        playerControls = new PlayerControls();
    }
    void OnEnable()
    {
        playerControls.Enable();
    }
    void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return playerControls.Player.Movement.ReadValue<Vector2>();
    }
    public Vector2 GetMouseDelta()
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }
    public bool PlayerJumpedThisFrame()
    {
        return playerControls.Player.Jump.triggered;
    }
    public bool PlayerChangedCamera()
    {
        return playerControls.Player.ChangeCamera.triggered;
    }
    public bool ThrowBomb()
    {
        return playerControls.Player.ThrowBomb.triggered;
    }
}
