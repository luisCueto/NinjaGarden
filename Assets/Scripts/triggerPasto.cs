using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerPasto : MonoBehaviour
{
    private bool cambioP = false;
    private string objetoCol;

    [SerializeField]
    GameObject personaje;
    [SerializeField]
    GameObject planta;
    // Start is called before the first frame update
    void Start()
    {
        
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
            personaje.transform.position = new Vector3(planta.transform.position.x, -2, planta.transform.position.z);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name);
        if(other.tag == "planta")
        {
            personaje.transform.position = new Vector3(planta.transform.position.x, 0.5f, planta.transform.position.z);
            planta.transform.position = new Vector3(personaje.transform.position.x, -2, personaje.transform.position.z);
        }
        
    }
}