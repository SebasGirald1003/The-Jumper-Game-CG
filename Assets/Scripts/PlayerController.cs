using UnityEngine;
using UnityEngine.InputSystem; // Importante

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerControls controls;
    private bool isGrounded = false;

    public float jumpForce = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controls = new PlayerControls();

        // Vinculamos el input Jump
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
            Debug.Log("Grounded");
        }
    }
}
