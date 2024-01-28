using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Helio : MonoBehaviour
{   

    [SerializeField] private int cantHelios; 
    [SerializeField] private float distanciaMaxima,cantFelicidadAgregada = 20; 
                     public TMP_Text TMPcantHelios;
                     public NavScript navMesh;
    [SerializeField] private GameObject PFsonidoHelio,PFsonidoPuerta,PFsonidoAgarrarHelio,textoPrecioneE,textoPrecioneEinteractuar;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (cantHelios < 10)
        {
            TMPcantHelios.text = string.Format("{0:0}", cantHelios);
        }
        if (cantHelios > 9)
        {
            TMPcantHelios.text = string.Format("{0:00}", cantHelios);
        }


      //  if (Input.GetKeyDown(KeyCode.E))
       // {
            Recolectar();
       // }
        if(Input.GetKeyDown(KeyCode.Q) && cantHelios > 0)
        {
            UsarHelio();
        }
    }

        void Recolectar()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanciaMaxima))
        {
            if (hit.collider.CompareTag("Helio"))
            {
                textoPrecioneE.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                Instantiate(PFsonidoHelio, this.transform.position, this.transform.rotation);

                cantHelios++;
                Destroy(hit.collider.gameObject);
                 
                }
            }

            if (hit.collider.CompareTag("Puerta"))
            {
                textoPrecioneEinteractuar.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    Instantiate(PFsonidoPuerta, this.transform.position, this.transform.rotation);

                     Puerta puertaScript = hit.collider.GetComponent<Puerta>();
                     puertaScript.AbrirPuerta(3);


                  // hit.collider.gameObjet.Puerta.AbrirPuerta();
                 
                }
            }


        }
        else
        {
        textoPrecioneE.SetActive(false);
        textoPrecioneEinteractuar.SetActive(false);

        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * distanciaMaxima);
    }

    public void UsarHelio()
    {
        
        Debug.Log(" usarhElio");
        cantHelios --;
        Instantiate(PFsonidoHelio, this.transform.position, this.transform.rotation);
        navMesh.AumentarFelicidad(cantFelicidadAgregada);
            
    }

}
