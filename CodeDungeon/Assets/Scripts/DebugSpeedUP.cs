using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSpeedUP : MonoBehaviour
{
    public GameObject game;

    public void pularhora()
    {
        var scri = game.GetComponent<Game>();

        scri.lastComida = scri.lastComida.AddHours(-1);
        scri.lastCagar = scri.lastCagar.AddHours(-1);
        scri.lastSujeira = scri.lastSujeira.AddHours(-1);
        scri.lastAgua = scri.lastAgua.AddHours(-1);
    }
}
