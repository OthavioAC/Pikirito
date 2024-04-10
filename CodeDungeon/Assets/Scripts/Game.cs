using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    public RawImage newEgg;
    public GameObject piriquito = null;
    

    // Start is called before the first frame update
    void Start()
    {
        newEgg.enabled = false;
        if (piriquito == null)
        {
            newEgg.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
