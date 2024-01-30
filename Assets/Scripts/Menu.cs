using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{      
        [SerializeField] private AudioSource sonido/*,otroAudioSource*/;

    public FadeInFadeOut fade;
    
    // Start is called before the first frame update
    void Start()
    {

    }
   
     public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    public void CargarJuego()
    {
        // Obtenemos el nombre de la escena actual

        // Cargamos la misma escena para reiniciarla
        if (sonido != null)
        sonido.Play();
             StartCoroutine(esperarYcargar(2,"Environment"));

       // SceneManager.LoadScene("Environment");
    }
    public void Tutorial()
    {
        if (sonido != null)
            sonido.Play();
    // SceneManager.LoadScene("Tutorial");
             StartCoroutine(esperarYcargar(2,"Tutorial"));
    }

    public void loadScene(string levelToLoad)
    {
        if (sonido != null)
            sonido.Play();
        fade.HacerFade(0, 1, 1);
        Time.timeScale = 1f;
        StartCoroutine(esperarYcargar(1, levelToLoad));
        Cursor.visible = true;
    }

     private IEnumerator esperarYcargar(float delay, string nombreEscena)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nombreEscena);
    }


}

