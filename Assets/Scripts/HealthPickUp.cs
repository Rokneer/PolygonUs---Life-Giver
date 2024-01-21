using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
  private GameManager gameManager;
  private HealthSpawner healthSpawner;
  void Start()
  {
    gameManager = GameManager.Instance;
    healthSpawner = FindObjectOfType<HealthSpawner>();
  }
  private void OnTriggerEnter(Collider collider)
  {
    if (collider.CompareTag("Player"))
    {
      if (gameManager.health >= 3) return;
      gameManager.ChangeHealth();
      healthSpawner.spawnedHeartsNumber--;
      Destroy(gameObject);
    }
  }
}