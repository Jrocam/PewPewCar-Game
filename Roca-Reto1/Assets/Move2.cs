using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour {
	public float movementSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3( 0f , 0f , Input.GetAxis( "verti2" ) ) * 
			Time.deltaTime 
			* movementSpeed);
		transform.Rotate( new Vector3( 0f , Input.GetAxis( "hori2" ) , 0f ) );
	}
}
