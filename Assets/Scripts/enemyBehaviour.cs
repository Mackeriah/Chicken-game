using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    private float speed;
    public GameObject pond;
    private bool headingToPond = false;

    // Start is called before the first frame update
    void Start()
    {
        speed =  Random.Range(5f, 12f);
        pond = GameObject.Find("pond");

    }

    // Update is called once per frame
    void Update()
    {

        if (References.thePlayer != null && headingToPond == false)  // if the player exists
        {            
            // Ensure enemy physics will work
            Rigidbody ourRigidBody = GetComponent<Rigidbody>();

            // Calculate direction and distance to travel to the pond
            Vector3 vectorToPond = References.thePlayer.transform.position - transform.position;

            // Use this as our velocity but normalize the value to 1 metre and then multiply by our speed
            ourRigidBody.velocity = vectorToPond.normalized * speed;

            // calculate where player is
            Vector3 playerPosition = new Vector3(References.thePlayer.transform.position.x, transform.position.y, References.thePlayer.transform.position.z);

            // look at them
            transform.LookAt(playerPosition);
        }

        if (References.thePlayer != null)  // if the player exists
        {
            // Ensure enemy physics will work
            Rigidbody ourRigidBody = GetComponent<Rigidbody>();

            // Calculate direction and distance to travel to the pond
            Vector3 vectorToPond = pond.transform.position - transform.position;

            // calculate where the pond is
            Vector3 pondPosition = new Vector3(pond.transform.position.x, transform.position.y, pond.transform.position.z);

            float distance = (transform.position - pondPosition).magnitude;

            if (distance < 50f)
            {
                headingToPond = true;

                // Use this as our velocity but normalize the value to 1 metre and then multiply by our speed
                ourRigidBody.velocity = vectorToPond.normalized * speed;

                // look at them
                transform.LookAt(pondPosition);
            }
            
        }




    }

    private void OnCollisionEnter(Collision thisCollision)  // When the enemy collides with another GameObject
    {
        GameObject theirGameObject = thisCollision.gameObject;  // store that GameObject in the variable theirGameObject (so we can access it's Components)

        if (theirGameObject.GetComponent<PlayerBehaviour>() != null)  // if the thing we hit has a PlayerBehaviour component
        {
            HealthSystem theirHealthSystem = theirGameObject.GetComponent<HealthSystem>();  // store its HealthSystem in a variable theirHealthSystem so we can access it

            if (theirHealthSystem != null)  // if the GameObject actually had a HealthSystem component
            {
                theirHealthSystem.TakeDamage(1);  // call the function 'TakeDamage' which is inside the GameObject's HealthSystem and pass the function our damage variable (e.g. 1)
            }
        }
    }
}
