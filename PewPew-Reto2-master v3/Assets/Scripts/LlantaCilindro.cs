using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlantaCilindro : MonoBehaviour {

    public WheelCollider wheelCollider;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void FixedUpdate() {
        UpdateWheelHeight(this.transform, wheelCollider);
    } 

    void UpdateWheelHeight(Transform wheelTransform, WheelCollider collider)
    {

        Vector3 localPosition = wheelTransform.localPosition;
        Quaternion q = collider.GetComponentInParent<Transform>().rotation;

        WheelHit hit = new WheelHit();

        // see if we have contact with ground

        if (collider.GetGroundHit(out hit))
        {

            float hitY = collider.transform.InverseTransformPoint(hit.point).y;

            localPosition.y = hitY + collider.radius;

        }
        else
        {

            // no contact with ground, just extend wheel position with suspension distance

            localPosition = Vector3.Lerp(localPosition, -Vector3.up * collider.suspensionDistance, .05f);


        }

        // actually update the position

        wheelTransform.localPosition = localPosition;
        wheelTransform.localRotation = Quaternion.Euler(0f, collider.steerAngle, 0f);

    }
}
