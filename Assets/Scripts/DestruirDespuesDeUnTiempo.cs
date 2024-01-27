using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirDespuesDeUnTiempo : MonoBehaviour
{
    public float tiempoParaDestruir;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("destruir"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator destruir()
    {
        yield return new WaitForSeconds(tiempoParaDestruir);
        Destroy(gameObject);
    }
}
