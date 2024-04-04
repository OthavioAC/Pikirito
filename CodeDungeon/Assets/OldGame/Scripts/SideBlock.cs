using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SideBlock : MonoBehaviour
{
    private bool blocked = false;
    public bool GetBlocked()
    {
        return blocked;
    }

    public void SetBlocked(bool bloc)
    {
        blocked = bloc;
    }
}
