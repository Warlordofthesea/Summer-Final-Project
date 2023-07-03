using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacer : MonoBehaviour
{
    public Transform[] waypoints;      // Array of waypoints the AI car will follow
    public float moveSpeed = 5f;       // Speed at which the AI car moves
    public float rotationSpeed = 2f;   // Speed at which the AI car rotates
    public float turnSpeedReductionFactor = 0.5f;   // Speed reduction factor during turns
    public int lapsToComplete = 3;     // Number of laps the AI car should complete

    private int currentWaypointIndex = 0;  // Index of the current waypoint
    private Quaternion targetRotation;     // Desired target rotation for steering
    private int lapsCompleted = 0;        // Number of laps completed by the AI car
    private Vector3 initialPosition;       // Initial position of the AI car

    private void Start()
    {
        // Store the initial position of the AI car
        initialPosition = transform.position;

        // Set the initial target rotation towards the first waypoint
        targetRotation = Quaternion.LookRotation(waypoints[currentWaypointIndex].position - transform.position, Vector3.up);
    }

    private void Update()
    {
        // Check if the AI car has completed the specified number of laps
        if (lapsCompleted >= lapsToComplete)
        {
            // Stop the AI car's movement
            return;
        }

        // Move towards the current waypoint
        MoveTowardsWaypoint();

        // Rotate towards the target rotation
        RotateTowardsTargetRotation();
    }

    private void MoveTowardsWaypoint()
    {
        // Check if the AI car has reached the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            // Increment the waypoint index to move to the next waypoint
            currentWaypointIndex++;

            // Check if the AI car has completed a lap
            if (currentWaypointIndex >= waypoints.Length)
            {
                // Reset the waypoint index to the start of the lap
                currentWaypointIndex = 0;

                // Increment the number of laps completed
                lapsCompleted++;
            }

            // Set the new target rotation towards the next waypoint
            targetRotation = Quaternion.LookRotation(waypoints[currentWaypointIndex].position - transform.position, Vector3.up);
        }

        // Calculate the desired speed based on the current movement speed and the speed reduction factor during turns
        float desiredSpeed = moveSpeed;
        float angleToWaypoint = Quaternion.Angle(transform.rotation, targetRotation);
        float turnSpeedReduction = Mathf.Lerp(1f, turnSpeedReductionFactor, angleToWaypoint / 180f);
        desiredSpeed *= turnSpeedReduction;

        // Move the AI car towards the current waypoint with the desired speed
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, desiredSpeed * Time.deltaTime);
    }

    private void RotateTowardsTargetRotation()
    {
        // Calculate the desired target rotation based on the heading and the direction towards the next waypoint
        Vector3 waypointDirection = waypoints[currentWaypointIndex].position - transform.position;
        Quaternion desiredRotation = Quaternion.LookRotation(waypointDirection, Vector3.up);

        // Smoothly rotate the AI car towards the desired target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }

    public void StartRace()
    {
        // Reset the position of the AI car to the initial position
        transform.position = initialPosition;

        // Reset the laps completed counter
        lapsCompleted = 0;

        // Set the initial target rotation towards the first waypoint
        targetRotation = Quaternion.LookRotation(waypoints[currentWaypointIndex].position - transform.position, Vector3.up);
    }
}