using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    // offset camera position
    public Vector3 offset;

    private void LateUpdate()
    {
        // follow target and add offset
        // this is added a vector3 (target position) to a vector3 (camera offset position) so it literally adds the x+x, y+y and z+z
        transform.position = target.position + offset; 
    }

}
