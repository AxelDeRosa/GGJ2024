using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{      
        [SerializeField] private AudioSource sonido/*,otroAudioSource*/;

    
    // Start is called before the first frame update
    void Start()
    {

    }
 
    // Update is called once per frame

        

   
     public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();

    }

    public void CargarJuego()
    {
        // Obtenemos el nombre de la escena actual

        // Cargamos la misma escena para reiniciarla
        sonido.Play();
             StartCoroutine(esperarYcargar(2,"Environment"));

       // SceneManager.LoadScene("Environment");
    }
    public void Tutorial()
    {
     sonido.Play();

    // SceneManager.LoadScene("Tutorial");
             StartCoroutine(esperarYcargar(2,"Tutorial"));


    }


     private IEnumerator esperarYcargar(float delay, string nombreEscena)
    {

       
        yield return new WaitForSeconds(delay);
        
     SceneManager.LoadScene(nombreEscena);


    }
}

