using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reaparecer : MonoBehaviour
{
    [SerializeField]
    GameObject personaje;
    [SerializeField]
    GameObject posicionRespawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            personaje.transform.position = posicionRespawn.transform.position;
        }
    }
}
