using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    // offset camera position
    public Vector3 offset;

    private void FixedUpdate()
    {
        // follow target and add offset
        // this is added a vector3 (target position) to a vector3 (camera offset position) so it literally adds the x+x, y+y and z+z
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }

} 
