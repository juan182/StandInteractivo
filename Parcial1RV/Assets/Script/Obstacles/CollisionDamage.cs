using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Buscar el script PlayerController y bajar la salud
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.health -= 1;
            }

            // Destruir este objeto inmediatamente
            Destroy(gameObject);
        }
    }
}
