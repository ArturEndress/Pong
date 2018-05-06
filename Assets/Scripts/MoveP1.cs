using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveP1 : MonoBehaviour {

    public float spd = 30;

    private void FixedUpdate()
    {
        float vertPress = Input.GetAxisRaw("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, vertPress)* spd;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
