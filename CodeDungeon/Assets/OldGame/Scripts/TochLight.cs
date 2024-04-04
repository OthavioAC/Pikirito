using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

public class TochLight : MonoBehaviour
{
    //[SerializeField] private float lightMin = 0.7f;
    //[SerializeField] private float lightMax = 1.0f;
    [SerializeField] private float OuterRadius = 2;
    [SerializeField] private float collightmax=10;
    [SerializeField] private float noiseCoef = 20;
    [SerializeField] private float intensityCoef = 0.5f;
    [SerializeField] private float Offset = 3f;
    private float collight=0;
    float xpoint;
    
    // Start is called before the first frame update
    void Start()
    {
        xpoint = Random.Range(0,1000);
    }

    // Update is called once per frame
    void Update()
    {
        //float intensity = Mathf.PingPong(Time.time, lightMax - lightMin) + lightMin;
        if(collight<collightmax)
        {
            collight+=1*Time.deltaTime;
           // Debug.Log(collight);
        }
        else
        {
            float intensity =  Mathf.PerlinNoise(xpoint,Time.time*noiseCoef);
            collight = 0;
            //float intensity = Random.Range(lightMin, lightMax);
            GetComponent<Light2D>().intensity = (intensity*intensityCoef)+Offset;
            GetComponent<Light2D>().pointLightOuterRadius = GetComponent<Light2D>().intensity * OuterRadius;
            //Debug.Log(intensity);
        }
    }
}
