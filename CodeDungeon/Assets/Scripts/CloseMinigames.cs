using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMinigames : MonoBehaviour
{
    public GameObject Cenario;
    public GameObject CenarioHud;
    public GameObject HudMinigames;

    public void ShowCenario()
    {
        HudMinigames.SetActive(false);
        Cenario.SetActive(true);
        CenarioHud.SetActive(true);
    }
}
