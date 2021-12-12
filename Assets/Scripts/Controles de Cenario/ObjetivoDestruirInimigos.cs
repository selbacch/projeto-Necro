using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjetivoDestruirInimigos : MonoBehaviour
{
    public TMP_Text textoObjetivo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Enemy");

        if (inimigos.Length == 0)
        {
            textoObjetivo.color = Color.green;
        }

    }
}
