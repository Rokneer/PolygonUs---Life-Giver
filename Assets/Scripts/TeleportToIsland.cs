using UnityEngine;
using UnityEngine.UI;

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
            print("Damaged! Oof.");
            switch (gameManager.health)
            {
                case 3:
                    gameManager.healthPips[2].enabled = false;
                    break;
                case 2:
                    gameManager.healthPips[1].enabled = false;
                    break;
                case 1:
                    gameManager.healthPips[0].enabled = false;
                    break;
                default: return;
            }
            gameManager.health--;
            collider.GetComponentInParent<Rigidbody>().transform.position = respawnPoint.position;
        }
    }
}
