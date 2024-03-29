using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour
{
    public Transform target;
    public Transform home;
    public Body firstBodySegment;
    public float range = 50;
    public float speed = 40;
    public LayerMask enemyMask;
    public bool dead;
    private void Update() {
        var step =  speed * Time.deltaTime; // calculate distance to move
        if (!dead)
        {
            if (target != null)
            {
                transform.LookAt(target);
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }
            else
            {
                transform.LookAt(home);
                transform.position = Vector3.MoveTowards(transform.position, home.position, step);
            }
    
            if (target != null && Vector3.Distance(target.position, home.position) > range)
            {
                target = null;
            }
        }
        else
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }

        if (firstBodySegment.dead)
        {
            dead = true;
        }

        CheckForIntruders();
    }

    public void CheckForIntruders()
    {
        Collider[] intruders = Physics.OverlapSphere(home.position, range, enemyMask);
        if (intruders.Length > 0)
        {
            target = intruders[0].transform;
        }
    }
}
