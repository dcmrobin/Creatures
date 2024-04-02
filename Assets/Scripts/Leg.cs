using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class Leg : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 5f; // Adjust this value to control the speed of movement

    private bool isMoving = false;

    private void Update() {
        // Check if the leg is not already moving and the distance to the target is greater than 0.7
        if (!isMoving && Vector3.Distance(transform.position, target.position) > 0.7f)
        {
            // Set isMoving to true to indicate that the leg is now moving
            isMoving = true;
        }

        // If the leg is moving
        if (isMoving)
        {
            // Calculate the direction towards the target
            Vector3 direction = (target.position - transform.position).normalized;

            // Calculate the amount to move this frame based on moveSpeed and deltaTime
            float moveAmount = moveSpeed * Time.deltaTime;

            // Move the leg towards the target smoothly
            transform.position += direction * moveAmount;

            // Smoothly rotate towards the target's position
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, moveAmount);

            // Check if the leg has reached the target
            if (Vector3.Distance(transform.position, target.position) <= 0.1f) // You can adjust this threshold as needed
            {
                // Set isMoving to false to stop the movement process
                isMoving = false;
            }
        }

        Cursor.lockState = CursorLockMode.Locked;
    }
}
