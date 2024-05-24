using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Minigames2Logic : MonoBehaviour
{
    public int points = 0;

    public TextMeshProUGUI valor1;
    public TextMeshProUGUI valor2;
    public TextMeshProUGUI sinal;

    public int respostaCerta=0;
    public int alternativa = 0;

    public TextMeshProUGUI resposta1;
    public TextMeshProUGUI resposta2;
    public TextMeshProUGUI resposta3;
    // Start is called before the first frame update
    void Start()
    {
        GenerateQuest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GenerateQuest()
    {
        var numMax = 10;
        var sinais = new string[4];
        sinais[0] = "+";
        sinais[1] = "-";
        sinais[2] = "*";
        sinais[3] = "/";
        if(points >= 50)
        {
            numMax = 100;
        }
        else if(points >=25)
        {
            numMax = 50;
        }
        else if(points>=10)
        {
            numMax = 20;
        }
        else
        {
            numMax = 10;
        }
        var valor1int = Random.Range(0, numMax + 1);
        var valor2int = Random.Range(0, numMax + 1);
        var randomSinal = sinais[Random.Range(0, 4)];
        if(randomSinal=="+")
        {
            respostaCerta = valor1int+valor2int;
        }
        else if(randomSinal == "-")
        {
            respostaCerta = valor1int - valor2int;
        }
        else if (randomSinal == "*")
        {
            respostaCerta = valor1int * valor2int;
        }
        else
        {
            bool ok = false;
            do
            {
                if (valor1int % valor2int == 0)
                {
                    respostaCerta = valor1int / valor2int;
                    ok = true;
                }
                else
                {
                    valor1int = Random.Range(0, numMax + 1);
                    valor2int = Random.Range(0, numMax + 1);
                }
            } while (!ok);
        }

        valor1.text = valor1int.ToString();
        valor2.text = valor2int.ToString();
        sinal.text = randomSinal;

        alternativa = Random.Range(0, 3);

        if (alternativa == 0)
        {
            resposta1.text = respostaCerta.ToString();
            var resp2 = (respostaCerta + (Random.Range(-numMax / 2, numMax / 2)));
            if (resp2 == respostaCerta) resp2+= 1;
            resposta2.text = resp2.ToString();
            var resp3 = (respostaCerta + (Random.Range(-numMax / 2, numMax / 2)));
            if (resp3 == respostaCerta) resp3 += 1;
            resposta3.text = resp3.ToString();
        }
        else if (alternativa == 1)
        {
            resposta2.text = respostaCerta.ToString();
            var resp3 = (respostaCerta + (Random.Range(-numMax / 2, numMax / 2)));
            if (resp3 == respostaCerta) resp3 += 1;
            resposta3.text = resp3.ToString();
            var resp1 = (respostaCerta + (Random.Range(-numMax / 2, numMax / 2)));
            if (resp1 == respostaCerta) resp1 += 1;
            resposta1.text = resp1.ToString();
        }
        else
        {
            resposta3.text = respostaCerta.ToString();
            var resp2 = (respostaCerta + (Random.Range(-numMax / 2, numMax / 2)));
            if (resp2 == respostaCerta) resp2 += 1;
            resposta2.text = resp2.ToString();
            var resp1 = (respostaCerta + (Random.Range(-numMax / 2, numMax / 2)));
            if (resp1 == respostaCerta) resp1 += 1;
            resposta1.text = resp1.ToString();
        }

    }

    public void ClicouNo1()
    {
        if(alternativa == 1)
        {
            Debug.Log("Acertou");
        }
        else
        {

            Debug.Log("eRROU");
        }
    }
    public void ClicouNo2()
    {
        if (alternativa == 2)
        {
            Debug.Log("Acertou");

        }
        else
        {

            Debug.Log("eRROU");
        }

    }
    public void ClicouNo3()
    {
        if (alternativa == 3)
        {
            Debug.Log("Acertou");

        }
        else
        {
            Debug.Log("eRROU");

        }

    }
}
