using UnityEngine;

public class CoinValue : MonoBehaviour
{
  private GameManager gameManager;
  private enum CoinType
  {
    Bronze = 1,
    Silver = 5,
    Gold = 10
  }
  [SerializeField] private CoinType coinType;

  void Start()
  {
    gameManager = GameManager.Instance;
  }
  void OnTriggerEnter(Collider collider)
  {
    if (collider.CompareTag("Player"))
      switch (coinType)
      {
        case CoinType.Bronze:
          AddCoins((int)CoinType.Bronze);
          gameObject.SetActive(false);
          break;
        case CoinType.Silver:
          AddCoins((int)CoinType.Silver);
          gameObject.SetActive(false);
          break;
        case CoinType.Gold:
          AddCoins((int)CoinType.Gold);
          gameObject.SetActive(false);
          break;
        default: break;
      }
  }
  void AddCoins(int coinValue)
  {
    gameManager.coinCount += coinValue;
    gameManager.coinText.text = gameManager.coinCount.ToString();
  }
}
