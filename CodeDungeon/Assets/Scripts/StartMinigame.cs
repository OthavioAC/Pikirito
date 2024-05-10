using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMinigame : MonoBehaviour
{
    public GameObject minigame;
    public GameObject telaMinigames;

    public void startMinigame()
    {
        telaMinigames.SetActive(false);
        minigame.SetActive(true);
    }

}
