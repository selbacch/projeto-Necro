using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjetivoDestruirInimigos : MonoBehaviour
{
    public TMP_Text objetivoTxt;
    public TMP_Text inimigosRestantesTxt;
    private int inimigosRestantes;


    // Start is called before the first frame update
    void Start()
    {
        inimigosRestantes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Enemy");
        inimigosRestantes = inimigos.Length;
        inimigosRestantesTxt.text = "Inimigos restantes: " + inimigosRestantes.ToString().PadLeft(2,'0');
        if (inimigosRestantes == 0)
        {
            objetivoTxt.color = Color.green;
            inimigosRestantesTxt.color = Color.green;
        }

    }
}
