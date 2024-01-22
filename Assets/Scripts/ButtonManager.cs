using UnityEngine;

public class ButtonManager : MonoBehaviour
{
  private GameManager gameManager;
  private ChestKey chestKey;

  void Start()
  {
    gameManager = GameManager.Instance;
    chestKey = GameObject.FindGameObjectWithTag("Key").GetComponent<ChestKey>();
  }
  void OnTriggerEnter(Collider collider)
  {
    if (collider.CompareTag("Player"))
    {
      chestKey.pressedKeyButtons++;
      Destroy(this);
    }
  }
}
