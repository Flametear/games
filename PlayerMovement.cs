using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;



    private void Awake()
    {
        //ref
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new(horizontalInput * speed, body.linearVelocityY);


        //player movement
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;

        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();


        //animation
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }


    private void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocityX, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
            grounded = true;
    }

}
