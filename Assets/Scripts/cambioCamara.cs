using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambioCamara : MonoBehaviour
{
    [SerializeField]
    Camera camara1;
    [SerializeField]
    Camera camara2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            camara1.gameObject.SetActive(false);
            camara2.gameObject.SetActive(true);
        }
    }
}
