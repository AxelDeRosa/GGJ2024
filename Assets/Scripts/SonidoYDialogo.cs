using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SonidoYDialogo : MonoBehaviour
{
    [SerializeField] private string texto;
    [SerializeField] private AudioSource sonido/*,otroAudioSource*/;
    [SerializeField] private TMP_Text TMPdialogo;
                     private bool usado /*,es2D*/;
    [SerializeField] private float segundosDuracion;


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
        if(!usado)
        {
            if (other.CompareTag("Player"))
            {
          //  Debug.Log("Player");
             evento();
            }
        }
    }

    private void evento()
    {

        TMPdialogo =  GameObject.FindGameObjectWithTag("dialogo").GetComponent<TMP_Text>();
        TMPdialogo.text = texto;
        Invoke("LimpiarDialogo", segundosDuracion);
        usado = true;

    /*    if (es2D)
        {
            sonido.Play();
        }
        else
        {
             otroAudioSource.clip = sonido.clip;
             otroAudioSource.Play();
        }
    */

        //otra forma de pensarlo

        sonido.Play();
    }
     private void LimpiarDialogo()
    {
        TMPdialogo.text = "";
    }
}
