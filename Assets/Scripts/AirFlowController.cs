using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AirFlowController : MonoBehaviour {
    Rigidbody rb;
    public Vector3 airFlowForce;

    private void Awake() {

        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision) {
        rb.AddForce(airFlowForce, ForceMode.Acceleration);
    }
}
