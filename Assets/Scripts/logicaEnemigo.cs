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
    Transform jugador;
    [SerializeField]
    float velocidadMovimiento;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        alerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);

        if (alerta)
        {
            Vector3 posicJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
            transform.LookAt(posicJugador);
            transform.position = Vector3.MoveTowards(transform.position, posicJugador, velocidadMovimiento*Time.deltaTime);
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
