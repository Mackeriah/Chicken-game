using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Never set the value of a public variable in code - a different value in the inspector will override the code without telling you
    // If you need to, set it in Start() instead
    public float speed;
    public GameObject eggPrefab;
    public float secondsBetweenShots;   // assigned in Inspector
    private float secondsSinceLastShot;

    // Start is called before the first frame update
    void Start()
    {
        References.thePlayer = gameObject;  // this assigns this gameObject as "thePlayer"
        secondsSinceLastShot = secondsBetweenShots;  // this is essentially resetting on creation
    }

    // Update is called once per frame
    void Update()
    {

        float maxDistanceToMove = speed * Time.deltaTime;
     
        // Find the new position we'll move to
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Ensure player physics will work
        Rigidbody ourRigidBody = GetComponent<Rigidbody>();

        // Set our velocity
        ourRigidBody.velocity = inputVector * speed;

        Vector3 movementVector = inputVector * maxDistanceToMove;
        Vector3 newPosition = transform.position + movementVector;

        // face the new position
        transform.LookAt(newPosition);


        // track time since last shot
        secondsSinceLastShot += Time.deltaTime;

        // If clicked, create a bullet at our current position
        if (secondsSinceLastShot >= secondsBetweenShots && Input.GetButton("Fire1")) 
        {
            // Instantiate is a function and the stuff after are arguments
            Instantiate(eggPrefab, transform.position + transform.forward, transform.rotation);
            secondsSinceLastShot = 0;
        }       

    }

}
