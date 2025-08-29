using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameController gameController;

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
        }
    }
}

