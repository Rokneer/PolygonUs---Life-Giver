using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  private static GameManager _instance;
  public static GameManager Instance
  { get { return _instance; } }

  // Coins
  private readonly int COIN_TOTAL = 50;
  [HideInInspector] public int coinCount;
  public TextMeshProUGUI coinText;
  public TextMeshProUGUI coinTotalText;

  // Health
  [HideInInspector] public int health;
  [SerializeField] private GameObject healthPipsParent;
  [HideInInspector] public Image[] healthPips;

  // Key
  [HideInInspector] public bool hasKey;
  public Image keyImage;

  void Awake()
  {
    if (_instance != null && _instance != this) Destroy(gameObject);
    else _instance = this;
  }
  void Start()
  {
    coinCount = 0;
    coinTotalText.text = "/ " + COIN_TOTAL.ToString();
    healthPips = healthPipsParent.GetComponentsInChildren<Image>();
    health = healthPips.Length;
  }
  void Update()
  {
    if (coinCount == COIN_TOTAL) print("Got all the coins, yay.");
    if (health <= 0) print("Welp. Ya dead, bye.");
    if (hasKey) print("Got key. Time for money.");
  }
}
