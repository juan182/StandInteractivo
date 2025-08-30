using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    //Audio
    public AudioClip hitSound; // Asignar desde Inspector
    public float hitSoundVolume = 1f;

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

            // Reproducir sonido si hay clip
            if (hitSound != null)
            {
                AudioSource.PlayClipAtPoint(hitSound, transform.position, hitSoundVolume);
            }

            // Destruir este objeto inmediatamente
            Destroy(gameObject);
        }
    }
}
