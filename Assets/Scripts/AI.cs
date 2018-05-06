using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {


    public Ball bola;

    public float spd = 30;

    public float learpTweak = 2f;

    private Rigidbody2D rigidBody;

    
    
    // Use this for initialization
	void Start () {

        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (bola.transform.position.y > transform.position.y)
        {
            Vector2 dir = new Vector2(0, 1).normalized;

            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, dir * spd, learpTweak * Time.deltaTime);
        }
       else if (bola.transform.position.y < transform.position.y)
        {
            Vector2 dir = new Vector2(0, -1).normalized;

            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, dir * spd, learpTweak * Time.deltaTime);
        }
        else
        {
            Vector2 dir = new Vector2(0, 0).normalized;

            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, dir * spd, learpTweak * Time.deltaTime);

        }
    }
}
