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
    [SerializeField] private GameObject PFsonidoHelio,textoPrecioneE;
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
                cantHelios++;
                Destroy(hit.collider.gameObject);
                 
                }
                
            }
        }
        else
        {
        textoPrecioneE.SetActive(false);

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