using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAcarro : MonoBehaviour {
    public float VerticalInput;
    public float HorizontalInput;
    public GameObject[] targets;
    public float angulo;
    public Vector3 productoCruz;
    public float maxAngle = 30;
    public float maxTorque = 300;
    private WheelCollider[] wheels;
    public GameObject wheelShape;
    public int contador = 0;
    public float anguloMin = 5f;
    public float TiempoReset = 0f;
    public float TiempoInicio = 0f;
    // Use this for initialization
    void Start()
    {
        wheels = GetComponentsInChildren<WheelCollider>();

        for (int i = 0; i < wheels.Length; ++i)
        {
            var wheel = wheels[i];

            // Poner ruedasderechas alrevez
            if (wheel.transform.localPosition.x < 0f)
            {
                wheel.transform.localScale = new Vector3(wheel.transform.localScale.x * -1f, wheel.transform.localScale.y, wheel.transform.localScale.z);
            }
        }
    }
    // Update is called once per frame
    void Update() {
        if(contador < targets.Length){
        
        GameObject target = targets[contador];
        
        angulo = Vector3.Angle(transform.forward, target.transform.position - transform.position);
        productoCruz = Vector3.Cross(transform.forward, target.transform.position - transform.position);
        if (contador.Equals(19))
        {
            maxTorque = 540;
        }
        //Gira cuando angulo entre trigger y personaje es menor que x
        if(angulo > anguloMin)
        {
            HorizontalInput = productoCruz.y > 0 ? 1f : -1f;
        }
        else
        {
            HorizontalInput = 0;
        }
        //Casos Mucha Velocidad
        if (contador.Equals(17))
        {
            VerticalInput = .4f;
        }
        else
        {
            VerticalInput = 1f;
        }
        //Voltear el carro si se bolca
        if (transform.rotation.x >= .8f || transform.rotation.x <= -.8f || transform.rotation.z >= .8f || transform.rotation.z <= -.8f)
        {
            TiempoReset += Time.deltaTime;
        }
        if(TiempoReset > 3)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 6f, this.transform.position.z);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            TiempoReset = 0f;
        }
        //Volver a Inicio si el carro se cae
        if (this.transform.position.y < -5)
        {
            TiempoInicio += Time.deltaTime;
        }
        if (TiempoInicio > 4)
        {
            this.transform.position = new Vector3(-8f, 6f, 0);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            TiempoInicio = 0f;
            contador = 0;
        }
        float angle = maxAngle * HorizontalInput;
        float torque = maxTorque * VerticalInput;

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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Trigger"))
        {
            contador++;
        }
    }
}
