using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niño : MonoBehaviour
{
    public float estadoNiño = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BarraUi.Barra = estadoNiño;
    }
}
