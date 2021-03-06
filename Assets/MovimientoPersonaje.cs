﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour {

    public GameObject lineaFin;

    public float speed;

    private bool caminando = false;
    private bool corriendo = false;

    private bool fin = false;

    // Use this for initialization
    void Start () {

    }

    void Update()
    {
        // TODO: Para colisiones: https://answers.unity.com/questions/657234/2d-object-collision.html

        if (fin) {
            return;
        }

        if (transform.position.y > lineaFin.transform.position.y) {
            fin = true;
            return;
        }

        // GetAxisRaw is unsmoothed input -1, 0, 1
        float v = Input.GetAxisRaw("Vertical");
        caminando = v == -1;
        corriendo = v == 1;
        float finalSpeed = speed;
        if (caminando) {
            finalSpeed /= 2;
        }
        else if (corriendo) {
            finalSpeed *= 2;
        }
        float h = Input.GetAxisRaw("Horizontal");

        // normalize so going diagonally doesn't speed things up
        Vector3 direction = new Vector3(h, 1, 0f).normalized;

        // translate
        transform.Translate(direction * finalSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        fin = true;
    }
}
