using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Transform posicionCerrada,PosicionAbieta;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LlamarLerpPosition(Vector3 start,Vector3 target,float duration)
    {
              StartCoroutine(LerpPosition(start,target,duration));
    }

    public void CerrarPuerta(float duration)
    {
              StartCoroutine(LerpPosition(PosicionAbieta.position,posicionCerrada.position,duration));
    }
       public void AbrirPuerta(float duration)
    {
        Debug.Log("llamaste a abrir puerta");
              StartCoroutine(LerpPosition(posicionCerrada.position,PosicionAbieta.position,duration));

    }
    IEnumerator LerpPosition(Vector3 startPosition, Vector3 targetPosition, float lerpDuration)
    {
        float timeElapsed = 0f;
        while (timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;

    } 
}
