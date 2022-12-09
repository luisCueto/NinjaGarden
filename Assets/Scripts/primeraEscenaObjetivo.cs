using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class primeraEscenaObjetivo : MonoBehaviour
{
    public static int contador;
    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (contador == 3)
        {
            playerMovement.paseSegundaEscena = true;
        }
    }
}
