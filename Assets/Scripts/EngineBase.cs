using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineBase : MonoBehaviour
{
    // how fast this object accelerates
    [SerializeField]
    public float acceleration = 5000f;

    // the velocity this object has when it loads into the scene
    [SerializeField]
    public Vector2 initialVelocity = Vector2.zero;

    // local references
    [HideInInspector]
    public Rigidbody2D ourRigidbody;

    void Start()
    {
        // populate ourRigidbody
        ourRigidbody = GetComponent<Rigidbody2D>();

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
        //calculate our force to add
        Vector2 forceToAdd = direction * acceleration * Time.deltaTime;
        // apply forceToAdd to ourRigidbody
        ourRigidbody.AddForce(forceToAdd);
    }
}
