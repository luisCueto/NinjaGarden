using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerLifeManager : MonoBehaviour
{
    public float vidaMaxima;
    public float vidaActual;

    [SerializeField]
    Image barraVida;
    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
