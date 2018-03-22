using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirTarget : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
        Vector3 posicionTarget = target.transform.position;
        posicionTarget.z = transform.position.z;
        Vector3 posicionCamara = transform.position;
        Vector3 movimiento = posicionTarget - posicionCamara;
        Vector3 movNormalizado = movimiento.normalized;
        if (movNormalizado.magnitude > movimiento.magnitude) {
            movNormalizado = movimiento;
        }
        transform.position = posicionCamara + movNormalizado;
	}
}
