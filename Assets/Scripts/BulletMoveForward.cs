using UnityEngine;
using System.Collections;

public class BulletMoveForward : MonoBehaviour
{
    private float acceleration = 50f;

    private float initialVelocity = 5f;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.up * initialVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 ForceToAdd = Vector2.up * acceleration * Time.deltaTime;

        rb.AddForce(ForceToAdd);
    }
}
