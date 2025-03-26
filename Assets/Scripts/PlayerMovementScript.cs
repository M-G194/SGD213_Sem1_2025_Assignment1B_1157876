using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5000f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Apply movement from input
        float HorizontalInput = Input.GetAxis("Horizontal");

        if (HorizontalInput != 0.0f)
        {
            Vector2 moveForce = Vector2.right * HorizontalInput * moveSpeed * Time.deltaTime;
            rb.AddForce(moveForce);
        } 
    }
}