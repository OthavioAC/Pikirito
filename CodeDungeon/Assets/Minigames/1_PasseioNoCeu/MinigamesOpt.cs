using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamesOpt : MonoBehaviour
{
    public GameObject Cenario;
    public GameObject CenarioHud;
    public GameObject HudMinigames;


    private void Start()
    {
        HudMinigames.SetActive(false);
    }

    public void HideCenario()
    {
        HudMinigames.SetActive(true);
        Cenario.SetActive(false);
        CenarioHud.SetActive(false);
    }
}
