using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private float speed = 20.0f;
    private float turnSpeed = 50.0f;
    private float horizontalInput;
    private float forwardInput;

    public Transform cameraPivot; // Reference to the camera's pivot point
    public float maxRotationAngle = 45.0f; // Maximum rotation angle for the camera

    private float currentRotationAngle = 0.0f; // Current rotation angle of the camera

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // This is where we get player inputs
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        // Calculate the desired rotation angle based on player input
        float desiredRotationAngle = currentRotationAngle + (turnSpeed * horizontalInput * Time.deltaTime);

        // Clamp the desired rotation angle within the limits
        desiredRotationAngle = Mathf.Clamp(desiredRotationAngle, -maxRotationAngle, maxRotationAngle);

        // Rotate the camera's pivot point with the clamped rotation angle
        cameraPivot.localRotation = Quaternion.Euler(0, desiredRotationAngle, 0);

        // Update the current rotation angle
        currentRotationAngle = desiredRotationAngle;
    }
}
