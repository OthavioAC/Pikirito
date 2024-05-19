using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMinigame : MonoBehaviour
{
    public Camera cam;
    public GameObject minigame;
    public GameObject telaMinigames;

    public void startMinigame()
    {
        telaMinigames.SetActive(false);
        minigame.SetActive(true);
        cam.transform.position = new Vector3(0,0,-10);
    }

}
