using UnityEngine;

public class ChestKey : MonoBehaviour
{
  private GameManager gameManager;

  void Start()
  {
    gameManager = GameManager.Instance;
  }
  void OnTriggerEnter(Collider collider)
  {
    if (collider.CompareTag("Player"))
    {
      gameManager.hasKey = true;
      gameManager.keyImage.enabled = true;
      Destroy(gameObject);
    }
  }
}
