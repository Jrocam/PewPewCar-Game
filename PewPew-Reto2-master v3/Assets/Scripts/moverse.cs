using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverse : MonoBehaviour {
    public GameObject Bala;
    public Rigidbody r;
	// Use this for initialization
    public float movementSpeed;
    public float rotatingSpeed;
	//menu
	public GameObject canvas;

    void Start () {
        r= GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        //r.velocity = new Vector3(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, 0f , Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime) ;
        transform.Translate(new Vector3(0f, 0f, Input.GetAxis("Vertical"))* movementSpeed * Time.deltaTime );
        transform.Rotate( new Vector3( 0f , Input.GetAxis( "Horizontal" ) * rotatingSpeed * Time.deltaTime, 0f ) );
		if (Input.GetKeyDown("Cancel"))
		{
			canvas.SetActive(true);
		}
        /*if(Input.GetButtonDown("Fire1"))
        {
            // Create the Bullet from the Bullet Prefab
            var BalaIni = Instantiate(
                Bala,
                new Vector3(0f, 0f, 0f) + transform.position,
                transform.rotation);

            // Add velocity to the bullet
            //bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

            // Destroy the bullet after 2 seconds
            Destroy(BalaIni, 2.0f);
        }*/
    }


}
