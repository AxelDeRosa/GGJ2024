using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
