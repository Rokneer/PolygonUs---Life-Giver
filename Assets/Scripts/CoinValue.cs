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
  [SerializeField] private int degreesPerSecond = 20;
  [SerializeField] private float amplitude = 0.5f;
  [SerializeField] private float frequency = 1f;
  private Vector3 posOffset;
  private Vector3 tempPos;

  void Start()
  {
    gameManager = GameManager.Instance;
    posOffset = transform.position;
  }
  void Update()
  {
    transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);
    tempPos = posOffset;
    tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
    transform.position = tempPos;
  }
  void OnTriggerEnter(Collider collider)
  {
    if (collider.CompareTag("Player"))
      switch (coinType)
      {
        case CoinType.Bronze:
          print("Bronze +" + (int)CoinType.Bronze);
          AddCoins((int)CoinType.Bronze);
          Destroy(gameObject);
          break;
        case CoinType.Silver:
          print("Silver +" + (int)CoinType.Silver);
          AddCoins((int)CoinType.Silver);
          Destroy(gameObject);
          break;
        case CoinType.Gold:
          print("Gold +" + (int)CoinType.Gold);
          AddCoins((int)CoinType.Gold);
          Destroy(gameObject);
          break;
        default: return;
      }
  }
  void AddCoins(int coinValue)
  {
    gameManager.coinCount += coinValue;
    gameManager.coinText.text = gameManager.coinCount.ToString();
  }
}
