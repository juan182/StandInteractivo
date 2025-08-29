using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Vida
    public int health = 5;

    //Movimiento
    float horizontal;
    public float speed = 5f;

    //Animacion
    private Animator animator;

    //RigidBody
    private Rigidbody2D rb;

    //Al empezar la escena
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        //Movimiento
        if (horizontal < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (horizontal > 0) transform.localScale = new Vector2(1, 1);

        //Animacion
        animator.SetBool("turn", horizontal != 0);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }
}
