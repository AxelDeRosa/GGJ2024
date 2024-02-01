using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Transform posicionCerrada,PosicionAbieta;
    AudioSource audio;
    public bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
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
       if (!isOpen)
       {
            audio.Play();
            isOpen = true;
            StartCoroutine(LerpPosition(posicionCerrada.position,PosicionAbieta.position,duration));
       }
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
