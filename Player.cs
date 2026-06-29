using UnityEngine;

public class Player : MonoBehaviour
{
    public float inputHorizontal;
    public float velocity;
    public Transform groundCheck;
    public LayerMask layer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        GetComponent<Rigidbody2D>().linearVelocityX = velocity * inputHorizontal;

        if(inputHorizontal == -1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if(inputHorizontal == 1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        bool isOnGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, layer);

        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            GetComponent<Rigidbody2D>().linearVelocityY = 5;
        }

        if(inputHorizontal != 0) 
        {
            GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
        }
    }
}
