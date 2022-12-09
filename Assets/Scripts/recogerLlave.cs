using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recogerLlave : MonoBehaviour
{
    [SerializeField]
    public bool conLlave;

    // Start is called before the first frame update
    void Start()
    {
        conLlave = false;   
    }

    // Update is called once per frame
    void Update()
    {
        Llave(conLlave);
    }

    
    public bool Llave(bool llave)
    {
        if (llave)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.tag == "Player")
        {
                Debug.Log("llave recogida");
            gameObject.SetActive(false);
            conLlave = true;
            playerMovement.tengoLlave = true;
        }
    }
}
