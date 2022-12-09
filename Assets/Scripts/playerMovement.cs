using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public float runSpeed = 3;
    public float rotationSpeed = 250;
    public Animator animator;
    private float x, y;

    public bool estoyAtacando;
    public float impulsoDeGolpe = 10f;

    public BoxCollider colliderArma;

    [SerializeField]
    Image barraVida;

    public float vidaActual;
    public float vidaMax;

    public static bool tengoLlave;
    public static bool paseSegundaEscena;

    // Start is called before the first frame update
    void Start()
    {
        desactivarColliderArma();
        vidaActual = vidaMax;
        tengoLlave = false;
        paseSegundaEscena = false;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);

        if (Input.GetKeyDown(KeyCode.H) && !estoyAtacando)
        {
            animator.SetTrigger("golpeo");
            estoyAtacando = true;
        }

        animator.SetFloat("velX", x);
        animator.SetFloat("velY", y);

        vidaActual = barraVida.fillAmount * 100;
    }

    private void FixedUpdate()
    {
        if (!estoyAtacando)
        {
            transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
            transform.Translate(0, 0, y * Time.deltaTime * runSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "cambioEscenario")
        {
            Scene escena = SceneManager.GetActiveScene();
            Debug.Log(escena.name);

            if (escena.name == "primerEscenario" && paseSegundaEscena)
            {
                SceneManager.LoadScene("segundaEscena");
            }
            else if (escena.name == "segundaEscena" && tengoLlave)
            {
                SceneManager.LoadScene("ultimaEscena");
            }

        }
        if (other.gameObject.tag == "katanaEnemy")
        {
            vidaActual -= 10;
            //Debug.Log("daño"); 
            barraVida.fillAmount = vidaActual / vidaMax;
            Debug.Log("vidaAct: " + vidaActual);
            if (vidaActual == 0)
            {
                SceneManager.LoadScene("gameOver");
            }
        }
        if(other.gameObject.tag == "katanaBOSS")
        {
            vidaActual -= 30;
            //Debug.Log("daño"); 
            barraVida.fillAmount = vidaActual / vidaMax;
            Debug.Log("vidaAct: " + vidaActual);
            if (vidaActual == 0)
            {
                SceneManager.LoadScene("gameOver");
            }
        }
    }

    public void dejeGolpear()
    {
        estoyAtacando = false;
    }

    public void activarColliderArma()
    {
        colliderArma.enabled = true;
    }
    public void desactivarColliderArma()
    {
        colliderArma.enabled = false;
    }
}
