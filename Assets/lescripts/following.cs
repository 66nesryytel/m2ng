using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target; // The object to follow (usually the player)
    public float smoothSpeed; // How quickly the camera should catch up to the target
    public Vector2 offset; // Offset from the target's position

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            GameObject playerObject = GameObject.FindWithTag("Player");

            Vector2 desiredPosition = (Vector2)target.position + offset;
            Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
    }
}
