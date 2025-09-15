using UnityEngine;
using UnityEngine.InputSystem; // Importante
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerControls controls;
    public GameObject textObject;
    private bool isGrounded = false;

    [Header("Movimiento")]
    public float speed = 5f;  
    public float jumpForce = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controls = new PlayerControls();
        textObject.SetActive(false);

        controls.Player.Jump.performed += ctx => Jump();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(speed, rb.linearVelocity.y, 0);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject); 
            textObject.SetActive(true);
            textObject.GetComponent<TextMeshProUGUI>().text = "GAME OVER!";
        }
    }
}
