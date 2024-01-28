using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInFadeOut : MonoBehaviour
{
    public Image panelImage;
    [SerializeField] private float alphaInicial,alphaFinal,duracion;

    void Start()
    {

        StartCoroutine(FadeIn(alphaInicial, alphaFinal, duracion));

    }
   
    public void HacerFade(float alphaInicial, float alphaFinal, float duracion)
    {
        StartCoroutine(FadeIn(alphaInicial, alphaFinal, duracion));
    }

    
    IEnumerator FadeIn(float alphaInicio, float alphaFin, float duracion)
    {
        float tiempoTranscurrido = 0f;
        Color color = panelImage.color;
        color.a = alphaInicio;

        while (tiempoTranscurrido < duracion)
        {
            color.a = Mathf.Lerp(alphaInicio, alphaFin, tiempoTranscurrido / duracion);
            panelImage.color = color;

            tiempoTranscurrido += Time.deltaTime;

            yield return null;
        }

        color.a = alphaFin;
        panelImage.color = color;
    }
}
