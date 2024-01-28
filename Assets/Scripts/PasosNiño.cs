using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasosNiño : MonoBehaviour
{
    public AudioClip[] sonidosDePasos;
    public AudioSource audioSource;
    public int numPrueba;
    // Start is called before the first frame update
    void Start()
    {
                audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PasosMarco()
    {
        numPrueba ++;
         if(numPrueba > sonidosDePasos.Length -1)
        {
            numPrueba = 0;
        }
        //Debug.Log("Marcos dio un paso , numprubea =" + numPrueba);
        //audioSource.clip = sonidosDePasos[Random.Range(0, sonidosDePasos.Length)];
        audioSource.clip = sonidosDePasos[numPrueba];

        audioSource.Play();
    }
}
