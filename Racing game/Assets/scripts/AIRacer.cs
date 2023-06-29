using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacer : MonoBehaviour
{
    public Transform[] waypoints;      // Array of waypoints the AI car will follow
    public float moveSpeed = 5f;       // Speed at which the AI car moves
    public float rotationSpeed = 2f;   // Base speed at which the AI car rotates
    public Transform frontTransform;   // Front transform of the AI car
    public Transform backTransform;    // Back transform of the AI car

    private int currentWaypointIndex = 0;  // Index of the current waypoint

    private void Start()
    {
        // Set the AI car's position to the first waypoint
        transform.position = waypoints[0].position;
    }

    private void Update()
    {
        // Move towards the current waypoint
        MoveTowardsWaypoint();

        // Rotate towards the next waypoint
        RotateTowardsWaypoint();
    }

    private void MoveTowardsWaypoint()
    {
        // Check if the AI car has reached the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            // Increment the waypoint index to move to the next waypoint
            currentWaypointIndex++;

            // Check if the AI car has reached the final waypoint
            if (currentWaypointIndex >= waypoints.Length)
            {
                // Reset the waypoint index to restart the path
                currentWaypointIndex = 0;
            }
        }

        // Move the AI car towards the current waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);
    }

    private void RotateTowardsWaypoint()
    {
        // Calculate the direction to the next waypoint
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
        direction.y = 0f; // Ensure the car doesn't tilt up or down

        // Determine the target rotation based on the front and back transforms
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

        // Calculate the rotation speed based on the movement speed
        float scaledRotationSpeed = rotationSpeed * moveSpeed;

        // Smoothly rotate the AI car towards the next waypoint using the scaled rotation speed
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, scaledRotationSpeed * Time.deltaTime);
    }
}