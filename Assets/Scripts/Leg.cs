using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class Leg : MonoBehaviour
{
    public Transform target;

    private void Update() {
        if (Vector3.Distance(transform.position, target.position) > 0.7)
        {
            transform.position = target.position;
        }

        Cursor.lockState = CursorLockMode.Locked;
    }
}
