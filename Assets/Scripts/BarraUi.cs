using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraUi : MonoBehaviour
{
    public RectTransform rectTransform;
    public static float Barra{get;set;}
    // Start is called before the first frame update
    void Start()
    {
     Barra = 100;
     rectTransform = GetComponent<RectTransform>();   
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.sizeDelta = new Vector2(Mathf.Clamp(Barra,0.0f,100f),100);
        GetComponent<RawImage>().color = Vector4.Lerp(new Vector4(1, .1f, 0.2f,1), new Vector4(0, 1, 0.2f, 1), Barra/100);
    }
}
