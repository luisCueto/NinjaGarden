using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class logicaEnemigo : MonoBehaviour
{
    public int hp = 3;
    public int dañoArma = 1;
    public Animator anim;

    [SerializeField]
    float rangoDeAlerta;

    /*public LayerMask capaDelJugador;
    [SerializeField]
    bool alerta;*/
    [SerializeField]
    GameObject jugador;
    [SerializeField]
    float velocidadMovimiento;

    public bool atacando;
    public bool impacto=false;

    [SerializeField]
    Collider colliderArma;

    [SerializeField]
    GameObject llave;
    [SerializeField]
    GameObject guardiaBOSS;

    int contador;

    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        anim = GetComponent<Animator>();
        jugador = GameObject.Find("ma");
        guardiaBOSS = GameObject.Find("guardiaBOSS");
        llave.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, jugador.transform.position) <= rangoDeAlerta && !atacando && !impacto)
        {
            var mirarPos = jugador.transform.position - transform.position;
            mirarPos.y = 0;
            var rotacion = Quaternion.LookRotation(mirarPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacion, 2);
            anim.SetBool("caminar", true);

            transform.Translate(Vector3.forward * 2 * Time.deltaTime);

            anim.SetBool("atacar", false);
        }
        if(Vector3.Distance(transform.position, jugador.transform.position) < 1.5 && !impacto)
        {
            anim.SetBool("caminar", false);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(jugador.transform.position-transform.position), 2);
            anim.SetBool("atacar", true);
            atacando = true;
        }

        /*
        alerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);
        Vector3 posicJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);

        if (alerta)
        {
            
            transform.LookAt(posicJugador);
            transform.position = Vector3.MoveTowards(transform.position, posicJugador, velocidadMovimiento*Time.deltaTime);
            anim.SetBool("walk", true);
            Debug.Log(Vector3.Distance(transform.position, jugador.position));
        }

        if(Vector3.Distance(transform.position, jugador.position) < 1f)
        {
            posicJugador = 
            anim.SetBool("walk", false);
            anim.SetBool("atacar", true);
        }*/

        if (gameObject.name == "guardiaBOSS")
        {
            llave.transform.position = guardiaBOSS.transform.position;
        }
        
        
    }

    public void finalAnim()
    {
        anim.SetBool("atacar", false);
        atacando = false;
    }

    public void activarColliderArma()
    {
        colliderArma.enabled = true;
    }
    public void desactivarColliderArma()
    {
        colliderArma.enabled = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "katanaPlayer")
        {
            //finalAnim();
            //impacto = true;
            //anim.SetBool("impacto", true);
            Debug.Log("impresion: " + other.gameObject.tag);
            hp -= dañoArma;
            
            if (hp <= 0)
            { 
                Debug.Log(gameObject.name);
                if (gameObject.name == "guardiaBOSS")
                {
                    llave.SetActive(true);
                }
                if(gameObject.name == "BOSS")
                {
                    SceneManager.LoadScene("final");
                }
                primeraEscenaObjetivo.contador += 1;
                Destroy(gameObject);
            }
        }
        
    }
}
