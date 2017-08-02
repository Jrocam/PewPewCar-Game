using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPersonaje : MonoBehaviour {

    public float movementSpeed = 5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3( 0f , 0f , Input.GetAxis( "Vertical" ) ) * 
            Time.deltaTime 
            * movementSpeed);
        transform.Rotate( new Vector3( 0f , Input.GetAxis( "Horizontal" ) , 0f ) );
	}
}
