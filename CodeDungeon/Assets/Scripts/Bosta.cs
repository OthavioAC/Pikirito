using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosta : MonoBehaviour
{
    public GameObject game;
    public GameObject coin;

    private void OnMouseEnter()
    {
        if (Input.GetMouseButtonDown(0))
        {
            coin.GetComponent<AnimationCoinGain>().game = this.game;
            Destroy(gameObject);
            Instantiate(coin, transform.position ,Quaternion.identity);

            var ind = -1;
            var i =0;

            foreach (GameObject poopObj in game.GetComponent<Game>().CocosInScreen)
            {
                if (poopObj == this.gameObject)
                {
                    ind = i;
                }
                i++;
            }
            if (ind >= 0)
            {
                game.GetComponent<Game>().poops.RemoveAt(ind);
                game.GetComponent<Game>().CocosInScreen.RemoveAt(ind);
            }
            else
            {
                Debug.Log("erro");
            }
        }
    }

}
