using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AnimationCoinGain : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject game;
    private bool animSubindo = true;
    private float timestop = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0,5),ForceMode2D.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animSubindo) timestop += Time.deltaTime;
        if (timestop > 1.3f)
        {
            animSubindo = false;
        }
        var upperLeftScreen = new Vector3(0, Screen.height-100, 0);
        var upperLeft = game.GetComponent<Game>().cam.ScreenToWorldPoint(upperLeftScreen);
        if (!animSubindo)
        {
            transform.position = Vector2.MoveTowards(transform.position, upperLeft, 10 * Time.deltaTime);
        }
        float distance = Vector3.Distance(this.transform.position, upperLeft);
        if(distance<=10.2)
        {
            game.GetComponent<Game>().moedas += 1;
            Destroy(gameObject);
        }
    }
}
