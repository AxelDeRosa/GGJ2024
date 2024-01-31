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
    public GameObject nextCollider;
    public GameObject removeObject;
    public FadeInFadeOut fade;
    public bool isEnding;
    public bool isTutorial;
    public float bajadaDeEstado = 3;
    public NavScript barraMarco;
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
        if (isEnding)
            fade.HacerFade(0,1,3);

        if (isTutorial)
            barraMarco.velocidadBajadaDeEstado = bajadaDeEstado;


        if (!usado)
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
        if (nextCollider != null)
             nextCollider.SetActive(true);

        if (removeObject != null)
            removeObject.SetActive(false);
   
            //otra forma de pensarlo
        if (sonido != null)
            sonido.Play();
    }
     private void LimpiarDialogo()
    {
        TMPdialogo.text = "";
    }
}
