using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform target;
    public float smoothing = 8f;
    public Vector3 offset;

    private float newX;
    private float newY;
    private float newZ;

    void Update()
    {
        if (target == null) return;

        newX = target.position.x + offset.x;
        newY = target.position.y + offset.y;
        newZ = target.position.z + offset.z;

        Vector3 newPos = new Vector3(newX, newY, newZ);
        Vector3 smoothedPos = Vector3.Lerp(target.position, newPos, smoothing * Time.deltaTime);
        transform.position = smoothedPos;
    }
}
