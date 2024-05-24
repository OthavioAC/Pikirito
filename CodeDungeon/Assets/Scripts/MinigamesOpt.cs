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
    public TextMeshProUGUI minigame2Text;



    private void Start()
    {
        minigame1Text.text = game.GetComponent<Game>().recordeMinigame1.ToString();
        minigame2Text.text = game.GetComponent<Game>().recordeMinigame2.ToString();
        HudMinigames.SetActive(false);
    }

    private void OnEnable()
    {
        minigame1Text.text = game.GetComponent<Game>().recordeMinigame1.ToString();
        minigame2Text.text = game.GetComponent<Game>().recordeMinigame2.ToString();
    }

    private void OnDisable()
    {
        minigame1Text.text = game.GetComponent<Game>().recordeMinigame1.ToString();
        minigame2Text.text = game.GetComponent<Game>().recordeMinigame2.ToString();

    }




    public void HideCenario()
    {
        HudMinigames.SetActive(true);
        Cenario.SetActive(false);
        CenarioHud.SetActive(false);
    }
}
