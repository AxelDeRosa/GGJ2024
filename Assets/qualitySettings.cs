using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class qualitySettings : MonoBehaviour
{
    void Start()
    {
        return;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality, true);
    }
}
