using UnityEngine;

public class Protagonista : Peaton {

    public GameObject lineaFin;

    public float speed;

    private bool caminando = false;
    private bool corriendo = false;

    private bool chocado = false;
    private bool fin = false;

    // Use this for initialization
    void Start() {

    }

    void Update() {
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
        Vector3 direction = new Vector3(h, chocado ? 0 : 1, 0f).normalized;

        // translate
        transform.Translate(direction * finalSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        chocado = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        chocado = false;
    }
}
