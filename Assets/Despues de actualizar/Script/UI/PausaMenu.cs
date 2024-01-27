using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PausaMenu : MonoBehaviour
{      
    public static bool Pausado = false;
    public GameObject PausaMenuUI;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausado)
            {
                Volver();
            }
            else
            {
                Pausar();
            }
        } 
        
        
    }
    public void Volver()
    {
        PausaMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Pausado = false;
    }
    public void Pausar()
    {
        PausaMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Pausado = true;
    }
     public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();

    }
}
