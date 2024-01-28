using System.Collections;
using UnityEngine;

public class SonidoPasos : MonoBehaviour
{
    public AudioClip[] sonidosDePasos;
    public AudioSource audioSource;
    public float intervaloDePasos = 1.0f;
    private int indice;

    private bool reproduciendoPasos = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (!reproduciendoPasos)
            {
                indice ++;
               if(indice > sonidosDePasos.Length -1)
                {
                    indice = 0;
                }
                // Reproduce un sonido de paso aleatorio
                //audioSource.clip = sonidosDePasos[Random.Range(0, sonidosDePasos.Length)];
                audioSource.clip = sonidosDePasos[indice];

                audioSource.Play();
                reproduciendoPasos = true;
                StartCoroutine(EsperarIntervalo());
            }
        }
    }

    IEnumerator EsperarIntervalo()
    {
        // Espera el intervalo antes de detener la reproducción
        yield return new WaitForSeconds(intervaloDePasos);

        // Detiene la reproducción del paso actual
        audioSource.Stop();
        reproduciendoPasos = false;
    }
}
    