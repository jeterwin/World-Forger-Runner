using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCamera : MonoBehaviour
{
    public Transform target;
    public float trailDistance = 5.0f;
    public float heightDiff = 3.0f;
    public float cameraDelay = 0.02f;
    void Update()
    {
        Vector3 followPos = target.position - target.forward * trailDistance;
        followPos.y += heightDiff;
        transform.position += (followPos - transform.position) * cameraDelay;
        transform.LookAt(target.transform);
    }
}
