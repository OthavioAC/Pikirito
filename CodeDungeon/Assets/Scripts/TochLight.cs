using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

public class TochLight : MonoBehaviour
{
    [SerializeField] private float lightMin = 0.7f;
    [SerializeField] private float lightMax = 1.0f;
    [SerializeField] private float OuterRadius = 2;
    [SerializeField] private float collightmax=10;
    [SerializeField] private float noiseConstant = 20;
    [SerializeField] private float intensityConstant = 0.5f; 
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
            float intensity =  Mathf.PerlinNoise(xpoint,Time.time*noiseConstant)+0.5f;
            collight = 0;
            //float intensity = Random.Range(lightMin, lightMax);
            GetComponent<Light2D>().pointLightOuterRadius = intensity*OuterRadius;
            GetComponent<Light2D>().intensity = (intensity*intensityConstant)*0.85f;
            Debug.Log(intensity);
        }
    }
}
