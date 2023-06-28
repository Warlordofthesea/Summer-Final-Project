using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacer : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoints the AIcar will follow
    public float moveSpeed = 5f;  // Speed at which the AI car moves

    private int currentWaypointIndex = 0; // Index of the current waypoint

    // Start is called before the first frame update
    private void Start()
    {
        // Set the AI car's posistion to the first waypoint
        transform.position = waypoints[0].position;
    }

    // Update is called once per frame
    private void Update()
    {
        // Move towards the current waypoint
        MoveTowardsWaypoint();
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
}