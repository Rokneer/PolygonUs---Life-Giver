using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private InputManager inputManager;
    [Header("Cameras")]
    [SerializeField] private GameObject firstPersonCamera;
    [SerializeField] private GameObject thirdPersonCamera;
    [SerializeField] private Image centerDotImage;

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
