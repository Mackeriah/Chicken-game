using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Player postiion is: " + References.thePlayer.transform.position);
        Debug.Log("Enemy postiion is: " + transform.position);
        

        if (References.thePlayer != null)  // if the player exists
        {
            // Ensure enemy physics will work
            Rigidbody ourRigidBody = GetComponent<Rigidbody>();

            // Calculate direction and distance to travel to the player (Note we're using the whole Static thing in References)
            Vector3 vectorToPlayer = References.thePlayer.transform.position - transform.position;

            // Use this as our velocity but normalize the value to 1 metre and then multiply by our speed
            ourRigidBody.velocity = vectorToPlayer.normalized * speed;

            // calculate where player is
            Vector3 playerPosition = new Vector3(References.thePlayer.transform.position.x, transform.position.y, References.thePlayer.transform.position.z);
            
            // look at them
            transform.LookAt(playerPosition);
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
