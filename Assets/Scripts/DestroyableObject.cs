using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bomb"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
