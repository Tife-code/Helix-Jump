using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    private float smooothSpeed = 0.04f;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, target.position + offset, smooothSpeed);
        transform.position = newPosition;
    }
}
