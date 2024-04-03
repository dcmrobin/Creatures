using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseKinematics : MonoBehaviour
{
    public GameObject[] bones;
    public float boneLength;
    public float limbLength;
    public Transform target;

    private void Start() {
        boneLength = bones[0].transform.localScale.z;
        limbLength = boneLength * bones.Length;
    }

    private void Update() {
        bones[0].transform.LookAt(target);
        for (int i = 1; i < bones.Length; i++)
        {
            bones[i].transform.LookAt(bones[i-1].transform.GetChild(0));
            bones[i].transform.position += bones[i].transform.forward;
        }

        if (Vector3.Distance(bones[0].transform.position, target.position) > boneLength / 2)
        {
            bones[0].transform.position += bones[0].transform.forward;
        }
    }
}
