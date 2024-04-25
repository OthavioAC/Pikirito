using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BlockMove : MonoBehaviour
{
    public GameObject gameCam;
    private int idBlock = -1;
    private bool fclicked = false;
    private bool restart = false;

    private void Start()
    {
        idBlock = gameCam.GetComponent<CameraMove>().blocks.Count;
        gameCam.GetComponent<CameraMove>().blocks.Add(false);
    }

    private void Update()
    {
        Debug.Log(gameCam.GetComponent<CameraMove>().blocks[idBlock]);
        if (fclicked)
        {
            gameCam.GetComponent<CameraMove>().blocks[idBlock] = true;
        }
        /*
         * 
            if(!Input.GetMouseButton(0))
            {
                fclicked = false;
                gameCam.GetComponent<CameraMove>().blocks[idBlock] = false;
            }
         */
    }

    public void clicked()
    {
        fclicked = true;
    }
}
