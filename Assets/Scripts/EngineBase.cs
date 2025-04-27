using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineBase : MonoBehaviour
{
    // How fast this enemy accelerates
    [SerializeField]
    public float acceleration = 5000f;

    // The velocity this object has when it loads into the scene
    [SerializeField]
    public Vector2 initialVelocity = Vector2.zero;

    // Local references
    // This needs to be public for EngineEnemy, but doesn't need to be seen in the editor
    [HideInInspector]
    public Rigidbody2D ourRigidbody;

    void Start()
    {
        ourRigidbody = GetComponent<Rigidbody2D>();

        // Set the initial velocity
        updateVelocity(initialVelocity);
    }

    public void updateVelocity(Vector2 velocity)
    {
        ourRigidbody.velocity = velocity;
    }

    /// <summary>
    /// Accelerate takes a direction as a parameter, and applies a force in this provided direction
    /// to ourRigidbody, based on the acceleration variables and the delta time.
    /// </summary>
    /// <param name="horizontalInput">A direction vector, expected to be a unit vector (magnitude of 1).</param>
    public void Accelerate(Vector2 direction)
    {
        // Calculate our force to add
        Vector2 forceToAdd = direction * acceleration * Time.deltaTime;
        // Apply forceToAdd to ourRigidbody
        ourRigidbody.AddForce(forceToAdd);
    }
}
