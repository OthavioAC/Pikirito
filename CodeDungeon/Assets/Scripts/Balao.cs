using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Balao : MonoBehaviour
{
    public GameObject[] icons = new GameObject[2];
    public string iconName = "food";
    private bool iconMake = false;
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,2);
    }

    // Update is called once per frame
    void Update()
    {
        if(!iconMake)
        {
            time += Time.deltaTime;
            if (time > 0.5)
            {
                iconMake = true;
                switch (iconName)
                {
                    case "food":
                        {
                            icons[0].SetActive(true);
                            break;
                        }
                    case "sujo":
                        {
                            icons[1].SetActive(true);
                            break;
                        }
                    case "sede":
                        {
                            icons[2].SetActive(true);
                            break;
                        }
                }
            }
        }
    }

    
}
