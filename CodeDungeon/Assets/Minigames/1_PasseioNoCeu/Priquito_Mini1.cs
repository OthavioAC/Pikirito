using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Priquito_Mini1 : MonoBehaviour
{
    public Camera cam;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (mousepos.x > 3) mousepos.x = 3;
        if(mousepos.x<-3) mousepos.x = -3;
        transform.position = new Vector2(Mathf.Lerp(transform.position.x, mousepos.x, Time.deltaTime*2), this.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("k");
    }
}
