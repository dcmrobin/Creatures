using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class Body : MonoBehaviour
{
    public Transform target;
    public float rigidity = 20;
    public bool dead;

    private void Update() {
        if (target != null && !dead)
        {
            var step =  rigidity * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    
            if (Mathf.Approximately(transform.position.x, target.position.x) && Mathf.Approximately(transform.position.y, target.position.y) && Mathf.Approximately(transform.position.z, target.position.z))
            {
                transform.rotation = target.rotation;
            }
        }

        CheckIfDead();
    }

    public void CheckIfDead()
    {
        if (target == null || dead)
        {
            dead = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }
        else if (target.parent.GetComponent<Body>() != null ? target.parent.GetComponent<Body>().dead : target.parent.GetComponent<Worm>() != null ? target.parent.GetComponent<Worm>().dead : dead)
        {
            dead = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
