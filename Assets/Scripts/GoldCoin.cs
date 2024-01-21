using UnityEngine;

public class GoldCoin : MonoBehaviour
{
  [HideInInspector] public bool gotGoldCoin;

  private void Awake()
  {
    gameObject.SetActive(false);
  }
  private void OnTriggerEnter(Collider collider)
  {
    if (collider.CompareTag("Player")) gotGoldCoin = true;
  }
}