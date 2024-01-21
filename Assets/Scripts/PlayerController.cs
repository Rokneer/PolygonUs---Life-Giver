using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject firstPersonCamera;
    public GameObject thirdPersonCamera;
    public Image centerDotImage;
    private InputManager inputManager;

    void Start()
    {
        inputManager = InputManager.Instance;
    }
    void Update()
    {
        ChangeCamera();
    }
    void ChangeCamera()
    {
        if (inputManager.PlayerChangedCamera())
        {
            if (firstPersonCamera.activeSelf)
            {
                firstPersonCamera.SetActive(false);
                thirdPersonCamera.SetActive(true);
                centerDotImage.enabled = false;
            }
            else if (thirdPersonCamera.activeSelf)
            {
                firstPersonCamera.SetActive(true);
                thirdPersonCamera.SetActive(false);
                centerDotImage.enabled = true;
            }
        }
    }
}
