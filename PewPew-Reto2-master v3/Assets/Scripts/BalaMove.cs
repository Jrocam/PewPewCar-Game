using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaMove : MonoBehaviour {
    public float projectileSpeed;
    //AUDIO
    public AudioClip ded1;
    public AudioClip ded2;
    private AudioSource source;
    

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        float rand = Random.Range(1.0f, 2.0f);

        if (rand > 1.5f)
            source.PlayOneShot(ded2,rand);
        else
            source.PlayOneShot(ded1,rand);




        if (other.tag.Equals("TERRENOS"))
        {

        }
        else
        {
            if (other.tag.Equals("P1") || other.tag.Equals("P2"))
            {
                if (other.tag.Equals("P1"))
                {
                    other.transform.position = new Vector3(0, 6, 0);
                    other.transform.rotation = Quaternion.Euler(0, 0, 0);
                    other.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    other.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
                }
                else
                {
                    other.transform.position = new Vector3(-8f, 6, 0);
                    other.transform.rotation = Quaternion.Euler(0, 0, 0);
                    other.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    other.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
                }

            }
            else
            {
                Destroy(other.gameObject);
            }
            
        }


        //Destroy(this.gameObject); si lo pones no suena
    }
}
