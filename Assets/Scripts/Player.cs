using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10;
    Vector2 rotation = Vector2.zero;
	public float mouseSensitivity = 3;

    private void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.position += new Vector3(-vertical, 0, horizontal) * speed;

        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
        transform.eulerAngles = new Vector2(0,rotation.y) * mouseSensitivity;
        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * mouseSensitivity, 0, 0);
    }
}
