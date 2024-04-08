using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class Leg : MonoBehaviour
{
    public Transform limbTarget;
    public Transform fixedTarget;

    private void Update() {
        if (limbTarget == null || fixedTarget == null)
            return;

        if (Vector3.Distance(limbTarget.position, fixedTarget.position) > 0.7)
        {
            limbTarget.position = fixedTarget.position;
        }
    }
}
