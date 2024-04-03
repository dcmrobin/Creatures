using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseKinematics : MonoBehaviour
{
    public GameObject[] bones;
    public float boneLength;
    public float limbLength;
    public Transform target;
    public Transform point;
    public int iterations = 10;

    private void Start() {
        boneLength = bones[0].transform.localScale.z;
        limbLength = boneLength * bones.Length;
    }

    private void Update() {
        bones[0].transform.LookAt(target);

        //for (int i = 0; i < iterations; i++)
        //{
            for (int b = 1; b < bones.Length; b++)
            {
                bones[b].transform.LookAt(bones[b-1].transform.GetChild(0));
                if (Vector3.Distance(bones[b].transform.position, bones[b-1].transform.GetChild(0).position) > boneLength / 1.5)
                {
                    bones[b].transform.position += bones[b].transform.forward;
                }
            }

            if (Vector3.Distance(bones[0].transform.position, target.position) > boneLength / 1.5)
            {
                bones[0].transform.position += bones[0].transform.forward;
            }

            //if (Vector3.Distance(bones[^1].transform.position, point.position) < 0.001)
            //{
            //    break;
            //}
        //}
    }
}
