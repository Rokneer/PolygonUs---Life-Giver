using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
  public Transform[] spawnPoints;
  public GameObject healthPickup;
  public Transform heartContainer;
  [HideInInspector] public int spawnedHeartsNumber = 0;
  int currentSpawnerIndex = 0;

  private void Start()
  {
    InvokeRepeating(nameof(SpawnHealth), 3f, 10f);
  }
  void SpawnHealth()
  {
    if (spawnedHeartsNumber >= 3) return;
    GameObject pickup = Instantiate(healthPickup, spawnPoints[currentSpawnerIndex].transform.position, Quaternion.identity, heartContainer);
    currentSpawnerIndex++;
    spawnedHeartsNumber++;
    if (currentSpawnerIndex == 3) currentSpawnerIndex = 0;
  }
}