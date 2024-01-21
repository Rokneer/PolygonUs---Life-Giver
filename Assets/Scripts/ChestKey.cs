using UnityEngine;

public class ChestKey : MonoBehaviour
{
  private GameManager gameManager;

  // Buttons
  [Header("Buttons")]
  [SerializeField] private int keyButtonsAmount;
  [HideInInspector] public int pressedKeyButtons;

  private void Awake()
  {
    ManageKeyVisibilty(false);
  }
  void Start()
  {
    gameManager = GameManager.Instance;
  }
  void Update()
  {
    if (pressedKeyButtons == keyButtonsAmount)
      ManageKeyVisibilty(true);

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
  void ManageKeyVisibilty(bool isHidden)
  {
    gameObject.GetComponent<MeshRenderer>().enabled = isHidden;
    gameObject.GetComponent<CapsuleCollider>().enabled = isHidden;
  }
}