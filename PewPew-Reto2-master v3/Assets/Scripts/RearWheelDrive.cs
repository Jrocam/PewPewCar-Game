using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RearWheelDrive : MonoBehaviour {

    private WheelCollider[] wheels;
    public string controlCarroH;
    public string controlCarroV;
    public string resetear;
    public string btninicio;
    public float maxAngle = 30;
    public float maxTorque = 300;
    public GameObject wheelShape;
    

    // here we find all the WheelColliders down in the hierarchy
    public void Start()
    {
        wheels = GetComponentsInChildren<WheelCollider>();

        for (int i = 0; i < wheels.Length; ++i)
        {
            var wheel = wheels[i];


            /* // create wheel shapes only when needed
            if (wheelShape != null)
            {
                var ws = GameObject.Instantiate(wheelShape);
                ws.transform.parent = wheel.transform;
            }*/

            // Poner ruedasderechas alrevez
            if (wheel.transform.localPosition.x < 0f)
            {
                wheel.transform.localScale = new Vector3(wheel.transform.localScale.x*-1f, wheel.transform.localScale.y, wheel.transform.localScale.z);
            }
        }
    }

    // this is a really simple approach to updating wheels
    // here we simulate a rear wheel drive car and assume that the car is perfectly symmetric at local zero
    // this helps us to figure our which wheels are front ones and which are rear
    public void Update()
    {
        //RESET CAR IN INICIO (DEPENDIENDO SI ES P1 o P2)
        if (this.tag.Equals("P1"))
        {
            if (Input.GetButtonDown(resetear))
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 6f, this.transform.position.z);
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            }
            if (Input.GetButtonDown(btninicio))
            {
                this.transform.position = new Vector3(0, 6f, 0);
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            }
        }
        else if(tag.Equals("P2"))
        {
            if (Input.GetButtonDown(resetear))
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 6f, this.transform.position.z);
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            }
            if (Input.GetButtonDown(btninicio))
            {
                this.transform.position = new Vector3(-8f, 6f, 0);
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            }
        }
        
        float angle = maxAngle * Input.GetAxis(controlCarroH);
        float torque = maxTorque * Input.GetAxis(controlCarroV);

        foreach (WheelCollider wheel in wheels)
        {
            // a simple car where front wheels steer while rear ones drive
            if (wheel.transform.localPosition.z > 0)
                wheel.steerAngle = angle;

            if (wheel.transform.localPosition.z < 0)
                wheel.motorTorque = torque;

            // update visual wheels if any
            if (wheelShape)
            {
                Quaternion q;
                Vector3 p;
                wheel.GetWorldPose(out p, out q);

                // assume that the only child of the wheelcollider is the wheel shape
                Transform shapeTransform = wheel.transform.GetChild(0);
                shapeTransform.position = p;
                shapeTransform.rotation = q;

                
            }

        }
    }
}
