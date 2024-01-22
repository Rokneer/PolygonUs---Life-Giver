using UnityEngine;
using TMPro;

public class Throwable : MonoBehaviour
{
    private InputManager inputManager;
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Cooldown")]
    public float throwCooldown;

    [Header("Throwing")]
    public float throwForce;
    public float throwUpwardForce;

    private bool readyToThrow;

    private void Start()
    {
        inputManager = InputManager.Instance;
        readyToThrow = true;
    }

    private void Update()
    {
        if (inputManager.ThrowBomb() && readyToThrow)
            Throw();
    }

    private void Throw()
    {
        readyToThrow = false;

        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        Vector3 forceDirection = cam.transform.forward;

        if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hit, 500f)) forceDirection = (hit.point - attackPoint.position).normalized;

        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;
        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}