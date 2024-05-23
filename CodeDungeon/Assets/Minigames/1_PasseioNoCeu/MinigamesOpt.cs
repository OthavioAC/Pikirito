using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinigamesOpt : MonoBehaviour
{
    public GameObject Cenario;
    public GameObject CenarioHud;
    public GameObject HudMinigames;
    public GameObject game;

    public TextMeshProUGUI minigame1Text;



    private void Start()
    {
        minigame1Text.text = game.GetComponent<Game>().recordeMinigame1.ToString();
        HudMinigames.SetActive(false);
    }

    private void OnEnable()
    {
        minigame1Text.text = game.GetComponent<Game>().recordeMinigame1.ToString();
    }

    private void OnDisable()
    {
        minigame1Text.text = game.GetComponent<Game>().recordeMinigame1.ToString();

    }




    public void HideCenario()
    {
        HudMinigames.SetActive(true);
        Cenario.SetActive(false);
        CenarioHud.SetActive(false);
    }
}
