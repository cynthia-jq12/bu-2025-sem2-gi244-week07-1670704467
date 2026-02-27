using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float gravityMultiplier = 1f;

    public bool isGameOver = false;

    private Rigidbody rb;
    private InputAction jumpAction;
    private bool IsOnGround = false;

    void Awake()
    {
        isGameOver = false;
        rb = GetComponent<Rigidbody>();
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics.gravity *= gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.triggered && IsOnGround == true && isGameOver == false)
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
            IsOnGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("hit" + collision.gameObject.name);
        //if (collision.gameObject.tag == "Ground")
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log(" GAME OVER");
            isGameOver = true;
        }
    }
}
