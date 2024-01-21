using UnityEngine;

public class TeleportToIsland : MonoBehaviour
{
    public Transform respawnPoint;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            gameManager.ChangeHealth(true);
            collider.GetComponentInParent<Rigidbody>().transform.position = respawnPoint.position;
        }
    }
}
