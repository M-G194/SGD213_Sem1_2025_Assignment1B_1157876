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
    
    public void HorizontalMovement(float HorizontalInput)
    {
        Vector2 moveForce = Vector2.right * HorizontalInput * moveSpeed * Time.deltaTime;
        rb.AddForce(moveForce);
    }
}