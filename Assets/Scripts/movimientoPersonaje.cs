using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movimientoPersonaje : MonoBehaviour
{
    public float runSpeed = 7;
    public float rotationSpeed = 250;
    /*public GameObject planta;
    public GameObject personaje;*/

    private bool trigger = false;

    public Animator animator;
    private float x, y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "cambioEscenario")
        {
            Scene escena = SceneManager.GetActiveScene();
            Debug.Log(escena.name);

            if (escena.name == "primerEscenario")
            {
                SceneManager.LoadScene("segundaEscena");
            }
            else if (escena.name == "segundaEscena")
            {
                SceneManager.LoadScene("terceraEscena");
            }

        }
    }
        
}
