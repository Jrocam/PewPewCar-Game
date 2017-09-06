using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCarro : MonoBehaviour {
    public WheelCollider LDI, LDD, LTI, LTD;
    public float FuerzaDeMotor;
    public float chancleta;
    public float cabrilla;
    public float frenoDemano;        
    public float rotacionMaximaDeLlantas;
    public float FuerzaDeFrenoDeMano;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        chancleta = Input.GetAxis("Vertical");
        cabrilla = Input.GetAxis("Horizontal");
        frenoDemano = Input.GetAxisRaw("Jump");
        LDD.motorTorque = chancleta * FuerzaDeMotor * Time.deltaTime;
        LDI.motorTorque = chancleta * FuerzaDeMotor * Time.deltaTime;

        LDD.steerAngle = cabrilla * rotacionMaximaDeLlantas;
        LDI.steerAngle = cabrilla * rotacionMaximaDeLlantas;

        


        if (frenoDemano > 0f)
        {
            LTI.brakeTorque = FuerzaDeFrenoDeMano;
            LTD.brakeTorque = FuerzaDeFrenoDeMano;
        }
        else
        {
            LTI.brakeTorque = 0f;
            LTD.brakeTorque = 0f;
        }
        if (Input.GetButtonDown("reset"))
        {
            this.transform.position = new Vector3(0, 6, 0);
        }

    }
}
