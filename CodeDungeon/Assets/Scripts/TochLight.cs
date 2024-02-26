using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TochLight : MonoBehaviour
{
    [SerializeField] private float lightMin = 0.7f;
    [SerializeField] private float lightMax = 1.0f;
    [SerializeField] private float OuterRadius = 2;
    [SerializeField] private float collightmax=10;
    private float collight=0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float intensity = Mathf.PingPong(Time.time, lightMax - lightMin) + lightMin;
        if(collight<collightmax)
        {
            collight+=1*Time.deltaTime;
            //Debug.Log(collight);
        }
        else
        {
            collight = 0;
            float intensity = Random.Range(lightMin, lightMax);
            GetComponent<Light2D>().pointLightOuterRadius = 2+intensity*OuterRadius;
            GetComponent<Light2D>().intensity = intensity;
        }
    }
}
