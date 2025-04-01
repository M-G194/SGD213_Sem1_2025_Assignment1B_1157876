using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    [SerializeField]
    private Vector2 passiveAcceleration = Vector2.zero;

    [SerializeField]
    private Vector2 initialVelocity = Vector2.zero;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = initialVelocity;
    }

    public void Move(Vector2 additionalForce)
    {
        Vector2 ForceToAdd = (passiveAcceleration + additionalForce) * Time.deltaTime;

        rb.AddForce(ForceToAdd);
    }
}
