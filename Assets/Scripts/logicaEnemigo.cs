using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class logicaEnemigo : MonoBehaviour
{
    public int hp = 3;
    public int dañoArma = 1;
    public Animator anim;

    public float rangoDeAlerta;
    public LayerMask capaDelJugador;
    [SerializeField]
    bool alerta;
    [SerializeField]
    GameObject jugador;
    [SerializeField]
    float velocidadMovimiento;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        jugador = GameObject.Find("ma");
    }

    // Update is called once per frame
    void Update()
    {
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
        }

        
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
            Debug.Log(other.gameObject.tag);
            hp -= dañoArma;
            

            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
