using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ganador : MonoBehaviour {

    public GameObject menu;
    public GameObject menu2;
    // Use this for initialization
    private AudioSource source;
    public AudioClip FinishLineSound;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("P1") || other.tag.Equals("P2"))
        {
            source.PlayOneShot(FinishLineSound);
            StartCoroutine(finishe(other.tag));

        }
    }
    IEnumerator finishe(string ganador)
    {
        yield return new WaitForSeconds(2.5f);
        if (ganador.Equals("P1"))
        {
            menu.SetActive(true);
        }
        else
        {
            menu2.SetActive(true);
        }
       
    }
}
