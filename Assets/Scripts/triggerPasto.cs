using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class triggerPasto : MonoBehaviour
{
    private bool cambioP = false;
    private string objetoCol;

    [SerializeField]
    GameObject personaje;
    [SerializeField]
    GameObject planta;

    public float vidaActual;
    public float vidaMax;
    [SerializeField]
    Image barraVida;
    // Start is called before the first frame update
    void Start()
    {
        vidaMax = 100;
        StopAllCoroutines();
    }

    // Update is called once per frame
    void Update()
    {
        if (cambioP)
        {
            if(objetoCol=="Player")
            if (Input.GetKeyDown(KeyCode.K))
            {
                    Debug.Log("cambio de personaje a Planta");
                    planta.transform.position = personaje.transform.position;
                    personaje.transform.position = new Vector3(planta.transform.position.x, -2, planta.transform.position.z);
            }

            if (objetoCol == "planta")
            {
                if (Input.GetKeyDown(KeyCode.H))
                {
                    Debug.Log("cambio de personaje a ninja");
                    personaje.transform.position = planta.transform.position;
                    planta.transform.position = new Vector3(personaje.transform.position.x, -2, personaje.transform.position.z);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            planta.transform.position = new Vector3(personaje.transform.position.x, 0, personaje.transform.position.z);
            personaje.transform.position = new Vector3(planta.transform.position.x, -200, planta.transform.position.z);

            /*vidaActual = barraVida.fillAmount * 100;
            vidaActual += 10 * Time.deltaTime;
            barraVida.fillAmount = vidaActual / vidaMax;*/
            StartCoroutine(corrutinaVida());
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "planta")
        {
            personaje.transform.position = new Vector3(planta.transform.position.x, 0, planta.transform.position.z);
            planta.transform.position = new Vector3(personaje.transform.position.x, -200, personaje.transform.position.z);
        }
        
    }

    IEnumerator corrutinaVida()
    {
        vidaActual = barraVida.fillAmount * 100;
        Debug.Log(vidaActual);
        while (vidaActual < 100)
        {
            yield return new WaitForSeconds(1.5f);
            vidaActual += 10;
            barraVida.fillAmount = vidaActual / vidaMax;
            
        }
    }
}
