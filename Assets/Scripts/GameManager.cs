using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  private static GameManager _instance;
  public static GameManager Instance
  { get { return _instance; } }

  [Header("Player")]
  public GameObject player;
  [Header("Coins")]
  public TextMeshProUGUI coinText;
  public TextMeshProUGUI coinTotalText;
  private readonly int COIN_TOTAL = 50;
  [HideInInspector] public int coinCount;

  [Header("UI")]
  [SerializeField] private GameObject winScreen;
  // Health
  [SerializeField] private GameObject healthPipsParent;
  [HideInInspector] public int health;
  [HideInInspector] public Image[] healthPips;

  // Key
  [Header("Key")]
  public Image keyImage;
  public GameObject chest;
  public GameObject goldCoin;
  [HideInInspector] public bool hasKey;
  private bool gotGoldCoin;

  void Awake()
  {
    if (_instance != null && _instance != this) Destroy(gameObject);
    else _instance = this;
    coinCount = 0;
  }
  void Start()
  {
    coinTotalText.text = "/ " + COIN_TOTAL.ToString();
    healthPips = healthPipsParent.GetComponentsInChildren<Image>();
    health = healthPips.Length;
    gotGoldCoin = goldCoin.GetComponent<GoldCoin>().gotGoldCoin;
    winScreen.SetActive(false);
  }
  void Update()
  {
    UpdateHealth();
    CheckCoinTotal();
    OpenChest();
  }
  public void ChangeHealth(bool damage = false)
  {
    if (damage)
    {
      health--;
      return;
    }
    health++;
    if (health >= 3) health = 3;
  }
  void UpdateHealth()
  {
    if (health <= 0) ResetGame();
    switch (health)
    {
      case 3:
        healthPips[2].enabled = true;
        healthPips[1].enabled = true;
        healthPips[0].enabled = true;
        break;
      case 2:
        healthPips[2].enabled = false;
        healthPips[1].enabled = true;
        healthPips[0].enabled = true;
        break;
      case 1:
        healthPips[2].enabled = false;
        healthPips[1].enabled = false;
        healthPips[0].enabled = true;
        break;
    }
  }
  void CheckCoinTotal()
  {
    if (coinCount == COIN_TOTAL)
    {
      if (winScreen.activeSelf) return;
      winScreen.SetActive(true);
      player.GetComponent<PlayerController>().enabled = false;
      player.GetComponent<PlayerMovement>().enabled = false;
    }
  }
  void OpenChest()
  {
    if (hasKey && !gotGoldCoin)
    {
      gotGoldCoin = true;
      goldCoin.SetActive(true);
      chest.GetComponentsInChildren<Transform>()[1].localRotation = Quaternion.Euler(-40f, 0, 0);
    }
  }
  void ResetGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
}
