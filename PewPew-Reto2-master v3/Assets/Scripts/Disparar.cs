using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour {
	//public Rigidbody balaRigid;
	public GameObject projectile;
	//Audio
	public AudioClip pewPew;
    public string botonDisparo;
	private AudioSource source;
	private float volLowRange = .4f;
	private float volHighRange = 1.2f;

	// Use this for initialization
	void Start() {
		//balaRigid = GetComponent<Rigidbody>();
		source = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update() {

		//transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
		//balaRigid.velocity = new Vector3(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, 0f , Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);
		if (Input.GetButtonDown(botonDisparo)) {
			float vol = Random.Range(volLowRange,volHighRange);
			source.PlayOneShot(pewPew, vol);
            

            GameObject throwThis = Instantiate(projectile,transform.position, transform.rotation);
            //solo aumenta la transforma x GameObject throwThis = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z+1f), transform.rotation);
            // Destroy the bullet after 2 seconds
            Destroy(throwThis, 2.0f);
		}

	}

}
