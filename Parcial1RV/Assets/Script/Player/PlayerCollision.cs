using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameController gameController;

    //Audio
    public AudioClip treeCollisionSound; // Asignar desde Inspector
    public float treeSoundVolume = 1f;   // Volumen ajustable

    void Start()
    {
        gameController = FindFirstObjectByType<GameController>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            if (gameController != null)
            {
                gameController.PlayerTocoArbol();
            }

            // Reproducir sonido si hay clip
            if (treeCollisionSound != null)
            {
                AudioSource.PlayClipAtPoint(treeCollisionSound, transform.position, treeSoundVolume);
            }
        }
    }
}

